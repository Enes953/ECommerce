using Core.Security.JWT;
using ECommerce.Application.Features.AppUsers.Dtos;
using ECommerce.Application.Services.AuthService;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace ECommerce.Application.Features.AppUsers.Commands.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommand, GoogleLoginDto>
    {

        private readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
           _authService = authService;
        }

        public async Task<GoogleLoginDto> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
        {
          var token = await _authService.GoogleLoginAsync(request.IdToken, 60);

            return new()
            {
                Token = token
            };
        }
    }
}
