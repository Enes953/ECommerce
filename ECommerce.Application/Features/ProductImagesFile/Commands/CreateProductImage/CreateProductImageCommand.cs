using ECommerce.Application.Features.ProductImagesFile.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Commands.CreateProductImage
{
    public class CreateProductImageCommand : IRequest<CreatedProductImageDto>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
