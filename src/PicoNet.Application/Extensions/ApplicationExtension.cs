using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PicoNet.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database
        
        // Health checks
        
        return services;
    }
}