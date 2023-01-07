using ECommerce.Application.Features.ProductImagesFile.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.ProductImagesFile.Queries.GetProductImages
{
    public class GetProductImagesQuery : IRequest<List<GetProductImagesDto>>
    {
        public string Id { get; set; }
    }
}
