using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories
{
    public class OrderRepository:EfRepositoryBase<Order,BaseDbContext>,IOrderRepository
    {
        public OrderRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
