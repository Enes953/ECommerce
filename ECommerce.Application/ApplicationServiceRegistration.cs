using Core.Application.Pipelines.Validation;
using ECommerce.Application.Services.Authentications;
using ECommerce.Application.Services.AuthService;
using ECommerce.Application.Services.UserService;
using ECommerce.Core.Application.Pipelines.Logging;
using ECommerce.Core.CrossCuttingConcerns.Logging.Serilog;
using ECommerce.Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddHttpClient();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IExternalAuthentication, AuthManager>();
            services.AddScoped<IInternalAuthentication, AuthManager>();

            services.AddSingleton<LoggerServiceBase, MsSqlLogger>();


            return services;
        }

    }
}
