using AutoMapper;
using ECommerce.Application.Features.ProductImagesFile.Commands.CreateProductImage;
using ECommerce.Application.Features.ProductImagesFile.Commands.DeleteProductImage;
using ECommerce.Application.Features.ProductImagesFile.Dtos;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<ProductImageFile, GetProductImagesDto>().ReverseMap();

            CreateMap<ProductImageFile, CreateProductImageCommand>().ReverseMap();
            CreateMap<ProductImageFile, CreatedProductImageDto>().ReverseMap();

            CreateMap<ProductImageFile, DeleteProductImageCommand>().ReverseMap();
            CreateMap<ProductImageFile, DeletedProductImageDto>().ReverseMap();
        }
    }
}