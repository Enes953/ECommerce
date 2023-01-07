using ECommerce.Application.Features.AppUsers.Commands.CreateUser;
using ECommerce.Application.Features.AppUsers.Commands.FacebookLogin;
using ECommerce.Application.Features.AppUsers.Commands.GoogleLogin;
using ECommerce.Application.Features.AppUsers.Commands.LoginUser;
using ECommerce.Application.Features.AppUsers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task <IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            CreatedUserDto createdUserDto = await Mediator.Send(createUserCommand);

            return Ok(createdUserDto);
        }
    }
}
