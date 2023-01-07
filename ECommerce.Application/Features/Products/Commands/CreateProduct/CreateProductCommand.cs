using ECommerce.Application.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand:IRequest<CreatedProductDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Stock { get; set; }
    }

    
}
