
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using task3_iconnect.Models;
using task3_iconnect.repo;
using task3_iconnect.user.model;
namespace task3_iconnect
{
    public static class Server
    {
        public static void ConfigureServices( this IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen();
          
           
            services.AddScoped<IUserInterface, UserRepo>();
            services.AddScoped<IpostsRepo, PostRepo>();
            services.AddScoped<Filters>();


        }
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
