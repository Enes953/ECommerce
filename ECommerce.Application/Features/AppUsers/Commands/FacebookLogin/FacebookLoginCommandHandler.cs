using Core.Security.JWT;
using ECommerce.Application.Features.AppUsers.Dtos;
using ECommerce.Application.Services.AuthService;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.AppUsers.Commands.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommand, FacebookLoginDto>
    {
        readonly IAuthService _authService;

        public FacebookLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<FacebookLoginDto> Handle(FacebookLoginCommand request, CancellationToken cancellationToken)
        {
            var token = await _authService.FacebookLoginAsync(request.AuthToken,60);
            return new()
            {
                Token = token
            };
        }
    }
}
