
using BasketAPI.Data;
using BuildingBlocks.Exceptions.Handler;
using BuildingBlocks.Logging;
using BuildingBlocks.Validations;
using Carter;
using FluentValidation;
using HealthChecks.UI.Client;
using Marten;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository,CachedBasketRepository>();
builder.Services.AddStackExchangeRedisCache(configure =>
{
    configure.Configuration = builder.Configuration.GetConnectionString("Redis");
});
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviours<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("Database")!);
})
.UseLightweightSessions();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!)
    .AddRedis(builder.Configuration.GetConnectionString("Redis")!);




var app = builder.Build();

app.MapGet("/test", () => "hi");
app.MapCarter();
app.UseExceptionHandler(opt => { });
app.UseHealthChecks("/baskethealth",
    new HealthCheckOptions()
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
app.Run();

