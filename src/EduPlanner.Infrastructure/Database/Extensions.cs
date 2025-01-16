using EduPlanner.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduPlanner.Infrastructure.Data;

public static class Extensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection("database"));
        
        
        var databaseOptions = configuration.GetRequiredSection("database")
            .Get<DatabaseOptions>() ?? throw new NullReferenceException();
        
        
        Console.WriteLine($"DatabaseOptions:\n  New -> {databaseOptions.NewConnectionString}\n  Old -> {databaseOptions.OldConnectionString}");
        services.AddDbContext<NewDbContext>(x => 
            x.UseMySql(databaseOptions.NewConnectionString, ServerVersion.AutoDetect(databaseOptions.NewConnectionString)));
        
        
        services.AddDbContextFactory<OldDbContext>(x => 
            x.UseMySql(databaseOptions.OldConnectionString, ServerVersion.AutoDetect(databaseOptions.OldConnectionString)));
        
        
        
        return services;
    }
    
}