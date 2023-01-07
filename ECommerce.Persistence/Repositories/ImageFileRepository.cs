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
    public class ImageFileRepository : EfRepositoryBase<ImageFile, BaseDbContext>, IImageFileRepository
    {
        public ImageFileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
