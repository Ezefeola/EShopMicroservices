var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
#region Services Area
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
#endregion Services Area

var app = builder.Build();

#region Middlewares Area
app.MapCarter();
#endregion Middlewares Area

app.Run();