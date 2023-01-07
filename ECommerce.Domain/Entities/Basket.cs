﻿using Core.Persistence.Repositories;
using ECommerce.Core.Security.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Basket:Entity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
