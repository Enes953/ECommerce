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
    public class InvoiceFileRepository : EfRepositoryBase<InvoiceFile, BaseDbContext>, IInvoiceFileRepository
    {
        public InvoiceFileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
