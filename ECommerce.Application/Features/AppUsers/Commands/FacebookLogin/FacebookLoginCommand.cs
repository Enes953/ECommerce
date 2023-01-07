using ECommerce.Application.Features.AppUsers.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.AppUsers.Commands.FacebookLogin
{
    public class FacebookLoginCommand:IRequest<FacebookLoginDto>
    {
        public string AuthToken { get; set; }
    }
}
