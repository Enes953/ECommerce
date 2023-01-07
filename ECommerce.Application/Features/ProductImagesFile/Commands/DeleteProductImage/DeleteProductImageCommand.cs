using ECommerce.Application.Features.ProductImagesFile.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Commands.DeleteProductImage
{
    public class DeleteProductImageCommand : IRequest<DeletedProductImageDto>
    {
        public string Id { get; set; }

        public string? ImageId { get; set; }
    }
}
