using Core.Persistence.Paging;
using ECommerce.Application.Features.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Models
{
    public class ProductListModel:BasePageableModel
    {
        public List<GetListProductDto> Items { get; set; }
    }
}
