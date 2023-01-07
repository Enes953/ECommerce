using ECommerce.Application.Services.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.AuthService
{
    public interface IAuthService:IExternalAuthentication,IInternalAuthentication
    {
    }
}
