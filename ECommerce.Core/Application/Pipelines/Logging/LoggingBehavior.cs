﻿using ECommerce.Core.CrossCuttingConcerns.Logging;
using ECommerce.Core.CrossCuttingConcerns.Logging.Serilog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ILoggableRequest
    {
        private readonly LoggerServiceBase _loggerServiceBase;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggingBehavior(LoggerServiceBase loggerServiceBase, IHttpContextAccessor httpContextAccessor)
        {
            _loggerServiceBase = loggerServiceBase;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<LogParameter> logParameters = new();
            logParameters.Add(new LogParameter
            {
                Type = request.GetType().Name,
                Value = request
            });

            LogDetail logDetail = new()
            {
                MethodName = next.Method.Name,
                Parameters = logParameters,
                AppUser = _httpContextAccessor.HttpContext == null ||
                       _httpContextAccessor.HttpContext.User.Identity.Name == null
                           ? "?"
                           : _httpContextAccessor.HttpContext.User.Identity.Name
            };

            _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));

            return next();
        }
    }
}
