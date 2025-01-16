using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EduPlanner.Infrastructure.Database;

public class NewDbContextFactory: IDesignTimeDbContextFactory<NewDbContext>
{
    public NewDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Server=localhost;Port=3306;User ID=root;Password=root123;Database=atsNew";
        var optionsBuilder = new DbContextOptionsBuilder<NewDbContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); // Podaj poprawny connection string
        return new NewDbContext(optionsBuilder.Options);
    }
}