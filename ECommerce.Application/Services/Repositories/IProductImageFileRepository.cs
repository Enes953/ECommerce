using Core.Persistence.Repositories;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Repositories
{
    public interface IProductImageFileRepository:IAsyncRepository<ProductImageFile>,IRepository<ProductImageFile>
    {
    }
}
