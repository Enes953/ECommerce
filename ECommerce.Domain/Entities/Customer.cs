using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Customer:Entity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }

        

        
    }
}
