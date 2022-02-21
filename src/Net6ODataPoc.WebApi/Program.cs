using System.Text.Json.Serialization;
using Microsoft.AspNetCore.OData;
using Net6ODataPoc.Application;
using Net6ODataPoc.Infrastructure;
using Net6ODataPoc.WebApi.Middlewares;
using Serilog;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    Log.Information("Starting host...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host
        .UseSerilog()
        .ConfigureAppConfiguration((_, config) => { config.AddEnvironmentVariables(prefix: "CONFIG_"); })
        ;

    builder.Services
        .AddApplication();
    builder.Services
        .AddInfrastructure(builder.Configuration);


    builder.Services
        .AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        })
        .AddOData(options =>
            options
                .Expand()
                .Filter()
                .OrderBy()
                .Select()
                .SetMaxTop(null)
                .SkipToken()
        );

    builder.Services
        .AddEndpointsApiExplorer();

    builder.Services
        .AddSwaggerGen();

    var app = builder.Build();

    app.UseInfrastructure();

    app.UseMiddleware<KestrelResponseHandlerMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapControllers();

    await app.RunAsync();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Host terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}
