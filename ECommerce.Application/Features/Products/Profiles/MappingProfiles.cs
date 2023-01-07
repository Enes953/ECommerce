using AutoMapper;
using Core.Persistence.Paging;
using ECommerce.Application.Features.Products.Commands.CreateProduct;
using ECommerce.Application.Features.Products.Commands.DeleteProduct;
using ECommerce.Application.Features.Products.Commands.UpdateProduct;
using ECommerce.Application.Features.Products.Dtos;
using ECommerce.Application.Features.Products.Models;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, GetListProductDto>()
            .ForMember(dto => dto.ProductImageFiles, opt => opt.MapFrom(product => product.ProductImageFiles))
            .ReverseMap();

            CreateMap<IPaginate<Product>,ProductListModel>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, CreatedProductDto>().ReverseMap();

            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, UpdatedProductDto>().ReverseMap();

            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, DeletedProductDto>().ReverseMap();

            CreateMap<Product,GetByIdProductDto>().ReverseMap();
        }
    }
}
