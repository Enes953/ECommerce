using ECommerce.Core.Security.Identity;

namespace Core.Security.JWT;

public interface ITokenHandler
{
    Token CreateAccessToken(int second,AppUser appUser);
    string CreateRefreshToken();

   
}