using ECommerce.Application.Features.ProductImagesFile.Dtos;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, DeletedProductImageDto>
    {
        IProductRepository _productRepository;

        public DeleteProductImageCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DeletedProductImageDto> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.Query().Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == int.Parse(request.Id));

            ProductImageFile? productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == int.Parse(request.ImageId));

            if (productImageFile!=null)
            product?.ProductImageFiles.Remove(productImageFile);
            await _productRepository.SaveAsync();

            return new();
        }
    }
}
