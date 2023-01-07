using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public object Failures { get; init; }

        public ValidationProblemDetails(object failures)
        {
            Title = "Validation error(s)";
            Failures = failures;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/validation";
            Detail = "";
            Instance = "";
        }
    }
}
