using ECommerce.Application.Features.AppUsers.Dtos;
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.Security.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.UserService
{
    public interface IUserService
    {
        Task<CreatedUserDto> CreateAsync(CreateUserDto model);
        Task UpdateRefreshToken(string refreshToken,AppUser user,DateTime accessTokenDate, int AddOnAccessTokenDate);
    }
}
