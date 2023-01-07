using ECommerce.Application.Features.AppUsers.Commands.FacebookLogin;
using ECommerce.Application.Features.AppUsers.Commands.GoogleLogin;
using ECommerce.Application.Features.AppUsers.Commands.LoginUser;
using ECommerce.Application.Features.AppUsers.Commands.RefreshTokenLogin;
using ECommerce.Application.Features.AppUsers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            LoginedUserDto loginedUserDto = await Mediator.Send(loginUserCommand);
            return Ok(loginedUserDto);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody]RefreshTokenLoginCommand refreshTokenLoginCommand)
        {
            RefreshedTokenLoginDto refreshedTokenLoginDto = await Mediator.Send(refreshTokenLoginCommand);
            return Ok(refreshedTokenLoginDto);
        }
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommand googleLoginCommand)
        {
            GoogleLoginDto googleLoginDto = await Mediator.Send(googleLoginCommand);
            return Ok(googleLoginDto);
        }
        [HttpPost("facebook-login")]
        public async Task<IActionResult> FacebookLogin(FacebookLoginCommand facebookLoginCommand)
        {
            FacebookLoginDto facebookLoginDto = await Mediator.Send(facebookLoginCommand);
            return Ok(facebookLoginDto);
        }
    }
}
