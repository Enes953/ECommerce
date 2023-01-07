using ECommerce.Application.Features.ProductImagesFile.Dtos;
using ECommerce.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Commands.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommand, ChangedShowcaseImageDto>
    {
        private readonly IProductImageFileRepository _productImageFileRepository;

        public ChangeShowcaseImageCommandHandler(IProductImageFileRepository productImageFileRepository)
        {
            _productImageFileRepository = productImageFileRepository;
        }

        public async Task<ChangedShowcaseImageDto> Handle(ChangeShowcaseImageCommand request, CancellationToken cancellationToken)
        {
            var query = _productImageFileRepository.Query()
                .Include(p => p.Products)
                      .SelectMany(p => p.Products, (pif, p) => new
                      {
                          pif,
                          p
                      });
            var data = await query.FirstOrDefaultAsync(p => p.p.Id == int.Parse(request.ProductId) && p.pif.Showcase);

            if (data != null)
                data.pif.Showcase = false;
            var image = await query.FirstOrDefaultAsync(p => p.pif.Id == int.Parse(request.ImageId));
            if (image != null)
                image.pif.Showcase = true;

            await _productImageFileRepository.SaveAsync();

            return new();
        }
    }
}
