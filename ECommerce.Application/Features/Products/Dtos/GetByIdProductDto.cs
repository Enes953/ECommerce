using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Dtos
{
    public class GetByIdProductDto
    {
        public int Id { get; set; } //hoca string olarak yaptı bunu hata alırsan dikkat et !!!
        public string Name { get; set; }
        public string Stock { get; set; }
        public int Price { get; set; }
    }
}
