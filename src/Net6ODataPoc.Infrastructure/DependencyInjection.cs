namespace Net6ODataPoc.Infrastructure;

using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Net6ODataPoc.Infrastructure.JsonStorage.Interfaces;
using Net6ODataPoc.Infrastructure.JsonStorage.Services;
using SignalRPoc.Server.Infrastructure.JsonStorage;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JsonStorageOptions>(configuration.GetSection(JsonStorageOptions.SectionName));

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSingleton<IFileProvider>(new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly()));

        services.AddSingleton<ICustomerReadService, CustomerReadService>();
        services.AddSingleton<IMigrationService, MigrationService>();
    }

    public static void UseInfrastructure(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();

        var migrationService = serviceScope.ServiceProvider.GetRequiredService<IMigrationService>();
        migrationService.MigrateStorage().Wait();
    }
}
