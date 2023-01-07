using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order:Entity
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
