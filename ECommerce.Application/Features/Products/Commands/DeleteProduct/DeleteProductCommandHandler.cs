using AutoMapper;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductDto>
    {
        IProductRepository _productRepository;
        IMapper _mapper;
        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<DeletedProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(p => p.Id == request.Id);
            Product? deletedProduct = await _productRepository.DeleteAsync(product);
            DeletedProductDto? deletedProductDto = _mapper.Map<DeletedProductDto>(deletedProduct);
            return deletedProductDto;
        }
    }
}
