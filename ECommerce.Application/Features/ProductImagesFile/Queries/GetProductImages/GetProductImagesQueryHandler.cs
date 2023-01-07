using ECommerce.Application.Features.ProductImagesFile.Dtos;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Queries.GetProductImages
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQuery, List<GetProductImagesDto>>
    {
        IProductRepository _productRepository;
        IConfiguration _configuration;

        public GetProductImagesQueryHandler(IProductRepository productRepository, IConfiguration configuration)
        {
            _productRepository = productRepository;
            _configuration = configuration;
        }

        public async Task<List<GetProductImagesDto>> Handle(GetProductImagesQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.Query().Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == int.Parse(request.Id));

            return product.ProductImageFiles.Select(p => new GetProductImagesDto
            {
               FilePath = $"{_configuration["BaseStorageUrl"]}/{p.FilePath}",
               FileName = p.FileName,
               Id= p.Id //burada id eklememizin sebebi resimi silebilmek için
            }).ToList();
        }
    }
}
