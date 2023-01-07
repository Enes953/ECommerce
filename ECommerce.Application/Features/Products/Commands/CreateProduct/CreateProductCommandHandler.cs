using AutoMapper;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Services.Hubs;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductHubService _productHubService;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IProductHubService productHubService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productHubService = productHubService;
        }

        public async Task<CreatedProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
           Product mapppedProduct = _mapper.Map<Product>(request);
           Product createdProduct  = await _productRepository.AddAsync(mapppedProduct);

           CreatedProductDto createdProductDto = _mapper.Map<CreatedProductDto>(createdProduct);
          await _productHubService.ProductAddedMessageAsync($"{request.Name} İsminde Ürün eklenmiştir.");
            return createdProductDto;
        }
    }
}
