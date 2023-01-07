using AutoMapper;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository, ILogger<UpdateProductCommandHandler> logger)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<UpdatedProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            Product updateProduct = await _productRepository.UpdateAsync(product);
            UpdatedProductDto updatedProductDto = _mapper.Map<UpdatedProductDto>(updateProduct);
            _logger.LogInformation("Product Güncellendi");
            return updatedProductDto;
        }
    }
}
