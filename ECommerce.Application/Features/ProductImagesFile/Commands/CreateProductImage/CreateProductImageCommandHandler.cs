using AutoMapper;
using ECommerce.Application.Abstractions.Storage;
using ECommerce.Application.Features.ProductImagesFile.Dtos;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Commands.CreateProductImage
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, CreatedProductImageDto>
    {
        IProductRepository _productRepository;
        IProductImageFileRepository _productImageFileRepository;
        IStorageService _storageService;
        IMapper _mapper;

        public CreateProductImageCommandHandler(IProductRepository productRepository, IProductImageFileRepository productImageFileRepository, IMapper mapper,IStorageService storageService)
        {
            _productRepository = productRepository;
            _productImageFileRepository = productImageFileRepository;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<CreatedProductImageDto> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

            Product product = await _productRepository.GetByIdAsync(request.Id);
            await _productImageFileRepository.AddRangeAsync(result.Select(r => new ProductImageFile
            {
                FileName = r.fileName,
                FilePath = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Product>() { product }
            }).ToList());
            await _productImageFileRepository.SaveAsync();
            return new();

            //var datas = await _storageService.UploadAsync("products-images", Request.Form.Files);
            //await _productImageFileRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            //{
            //    FileName = d.fileName,
            //    FilePath = d.pathOrContainerName,
            //    Storage = _storageService.StorageName
            //}).ToList());
            //await _productImageFileRepository.SaveAsync();

            //return Ok();
        }
    }
}
