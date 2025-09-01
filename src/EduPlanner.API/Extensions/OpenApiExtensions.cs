
using Microsoft.OpenApi;
using Scalar.AspNetCore;

namespace EduPlanner.API.Extensions;

internal static class OpenApiExtensions
{
    internal static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services)
    {
        services.AddOpenApi(opt =>
        {
            opt.OpenApiVersion = OpenApiSpecVersion.OpenApi3_0;
            
            
        });
        return services;
    }

    internal static IApplicationBuilder UseOpenApiDocumentation(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference(opt =>
        {
            opt.WithTitle("EduPlanner API");
            opt.WithTheme(ScalarTheme.Default);
            opt.WithDefaultHttpClient(ScalarTarget.JavaScript, ScalarClient.Axios);
        });

        return app;
    }
    
}