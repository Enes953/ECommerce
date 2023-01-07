using Core.Security.JWT;
using ECommerce.Application.Features.AppUsers.Dtos;
using ECommerce.Application.Services.AuthService;
using ECommerce.Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.AppUsers.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginedUserDto>
    {
        IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginedUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.UserNameOrEmail, request.Password, 60);
            return new()
            {
                Token = token
            };
        }
    }
}
