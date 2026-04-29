using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Net.Http.Headers;
using RePattern.Common.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RePattern.Api.Utils
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ExceptionDetails response;
            httpContext.Response.Headers.Append(HeaderNames.ContentType, MediaTypeNames.Application.Json);

            switch (exception)
            {
                case BaseException baseException:
                    httpContext.Response.StatusCode = baseException.StatusCode;
                    response = baseException.GetExceptionDetails();
                    break;

                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = new ExceptionDetails
                    {
                        Message = exception.Message ?? "An unexpected error occurred.",
                        Code = HttpStatusCode.InternalServerError.ToString(),
                    };
                    break;
            }


            await httpContext.Response.WriteAsJsonAsync(response, jsonOptions, cancellationToken);
            return true;
        }
    }
}
