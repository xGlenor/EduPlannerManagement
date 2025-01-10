using Keycloak.AuthServices.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduPlanner.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddKeycloakWebAppAuthentication(configuration);
        services.AddAuthorization();
        
        return services;
    }
}