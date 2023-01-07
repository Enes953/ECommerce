using ECommerce.Application.Features.AppUsers.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.AppUsers.Commands.LoginUser
{
    public class LoginUserCommand:IRequest<LoginedUserDto>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
