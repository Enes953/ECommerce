using Core.Application.Requests;
using ECommerce.Application.Features.Products.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetListProduct
{
    public class GetListProductQuery:IRequest<ProductListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
