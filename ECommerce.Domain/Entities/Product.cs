using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product:Entity
    {
        public string Name { get; set; }
        public string Stock { get; set; }
        public int Price { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }

        //public product(int id,string name, string stock, int price):this()
        //{
        //    ıd = id;
        //    name = name;
        //    stock = stock;
        //    price = price;
        //}

        //public product()
        //{

        //}
    }
}
