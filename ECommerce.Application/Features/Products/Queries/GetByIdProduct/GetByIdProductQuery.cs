using ECommerce.Application.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQuery:IRequest<GetByIdProductDto>
    {
        public int Id { get; set; }
    }
}
