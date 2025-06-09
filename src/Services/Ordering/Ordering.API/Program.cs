using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

#endregion Services

var app = builder.Build();

#region Middlewares

app.UseApiServices();

if(app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

#endregion Middlewares

app.Run();