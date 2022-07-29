
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using task3_iconnect;
using task3_iconnect.Models;
using task3_iconnect.repo;
using task3_iconnect.user.model;

var builder = WebApplication.CreateBuilder(args);
//UserContex
builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("task3_iconnectContext")));


builder.Services.ConfigureServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
