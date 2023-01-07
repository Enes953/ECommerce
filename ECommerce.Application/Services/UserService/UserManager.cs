using ECommerce.Application.Features.AppUsers.Dtos;
using ECommerce.Core.Application.Dtos;
using ECommerce.Core.CrossCuttingConcerns.Exceptions;
using ECommerce.Core.Security.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.UserService
{
    public class UserManager : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserManager(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreatedUserDto> CreateAsync(CreateUserDto model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                NameSurname = model.NameSurname,
            }, model.Password);

            CreatedUserDto createdUserDto = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                createdUserDto.Message = "Kullanıcı Başarıyla Oluşturuldu";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    createdUserDto.Message += $"{error.Code} - {error.Description}\n";

                    
                }
            }
            return createdUserDto;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate,int AddOnAccessTokenDate)
        {
          
            if(user != null)
            {
                user.RefreshToken= refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(AddOnAccessTokenDate);
               await _userManager.UpdateAsync(user);
            }
            else
            throw new Exception("Hata");
        }
    }
}
