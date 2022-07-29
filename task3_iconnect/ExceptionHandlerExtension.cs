using Microsoft.AspNetCore.Diagnostics;
namespace task3_iconnect
{
    public static class ExceptionHandlerExtension
    {
        
            public static void UseExceptionHandlerExtension(this IApplicationBuilder app)
            {
                app.UseMiddleware<ExceptionHandlerMiddleware>();
            }
        
    }
}
