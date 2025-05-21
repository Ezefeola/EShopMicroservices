using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

#endregion Services

var app = builder.Build();

#region Middlewares

app.UseApiServices();

#endregion Middlewares

app.Run();