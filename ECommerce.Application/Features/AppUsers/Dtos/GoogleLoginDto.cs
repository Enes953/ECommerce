﻿using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.AppUsers.Dtos
{
    public class GoogleLoginDto
    {
        public Token Token { get; set; }
    }
}
