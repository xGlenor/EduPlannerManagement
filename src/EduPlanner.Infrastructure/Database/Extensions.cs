using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduPlanner.Infrastructure.Database;

public static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection("database"));

        var databaseOptions = configuration.GetRequiredSection("database")
            .Get<DatabaseOptions>() ?? throw new NullReferenceException();

        Console.WriteLine($"Database connection string: {databaseOptions.ConnectionString}");
        services.AddDbContext<NewDbContext>(x =>
            x.UseMySql(databaseOptions.ConnectionString, ServerVersion.AutoDetect(databaseOptions.ConnectionString)));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.Scan(x => x.FromAssemblyOf<NewDbContext>()
            .AddClasses(c => c.AssignableTo(typeof(IReadOnlyRepository<>)), false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}