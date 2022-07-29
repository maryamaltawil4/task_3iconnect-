using Newtonsoft.Json;
using System.Net;

namespace task3_iconnect
{
    public class ExceptionHandler
    {
        
            private readonly RequestDelegate _next;

            public ExceptionHandler(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next.Invoke(context);
                }
                catch (Exception ex)
                {
                    await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
                }
            }

            private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
            {
                context.Response.ContentType = "application/json";
                int statusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonConvert.SerializeObject(new
                {
                    StatusCode = statusCode,
                    ErrorMessage = "Internal server error"
                });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                return context.Response.WriteAsync(result);
            }
        }
    }

