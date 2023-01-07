using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);
        Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
