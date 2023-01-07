using Core.Security.JWT;
using ECommerce.Application.Features.AppUsers.Dtos;
using ECommerce.Application.Services.UserService;
using ECommerce.Core.CrossCuttingConcerns.Exceptions;
using ECommerce.Core.Security.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly HttpClient _httpClient;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;

        public AuthManager(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, IHttpClientFactory httpClientFactory, SignInManager<AppUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
            _signInManager = signInManager;
            _userService = userService;
        }

        async Task<Token> CreateUserExternalAsync(AppUser user,string email,string name,UserLoginInfo info,int accessTokenLifeTime)
        {
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = email,
                        NameSurname = name
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }
            if (result)
            {
                await _userManager.AddLoginAsync(user, info);
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
               await _userService.UpdateRefreshToken(token.RefreshToken, user,token.Expiration,30);
                return token;
            }
            throw new Exception("Invalid external authentication");
        }
        public async Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime)
        {
            string accessTokenDto = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={_configuration["ExternalLoginSettings:Facebook:Client_ID"]}&client_secret={_configuration["ExternalLoginSettings:Facebook:Client_Secret"]}&grant_type=client_credentials");

            FacebookAccessTokenDto? facebookAccessTokenDto = JsonSerializer.Deserialize<FacebookAccessTokenDto>(accessTokenDto);

            string userAccessTokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={authToken}&access_token={facebookAccessTokenDto?.AccessToken}");


            FacebookAccessTokenValidationDto? validation = JsonSerializer.Deserialize<FacebookAccessTokenValidationDto>(userAccessTokenValidation);

            if (validation?.Data.IsValid !=null)
            {
                string userInfoDto = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={authToken}");

                FacebookUserInfoDto? userInfo = JsonSerializer.Deserialize<FacebookUserInfoDto>(userInfoDto);


                var info = new UserLoginInfo("FACEBOOK", validation.Data.UserId, "FACEBOOK");
                AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);


              return await CreateUserExternalAsync(user, userInfo.Email, userInfo.Name, info, accessTokenLifeTime);
            }
             throw new Exception("Invalid external authentication");
        }

        public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["ExternalLoginSettings:Google:Client_ID"] }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
            AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            return await CreateUserExternalAsync(user, payload.Email, payload.Name, info, accessTokenLifeTime);

            
            
        }
        public async Task<Token> LoginAsync(string userNameOrEmail, string password,int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByNameAsync(userNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(userNameOrEmail);

            if (user == null)
                throw new Exception("Hata");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 30);
                return token;

            }
            throw new Exception("Hata");
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
          AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(60,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 30);
                return token;
            }
            else
                throw new Exception("Hata");
        }
    }
}
