using EduPlaner.DbSeeder;using EduPlanner.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var connectionString = configuration.GetConnectionString("EduPlanerDb");

var services = new ServiceCollection();
services.AddTransient<FilesImporter>();
services.AddTransient<TimetableItemExporter>();
services.AddDbContext<NewDbContext>(x =>x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var serviceProvider = services.BuildServiceProvider();

await using var scope = serviceProvider.CreateAsyncScope();

var impoter = scope.ServiceProvider.GetRequiredService<FilesImporter>();
var exporter = scope.ServiceProvider.GetRequiredService<TimetableItemExporter>();

await foreach (var importedData in impoter.Import("data"))
{
    await exporter.Export(importedData);
}

Console.WriteLine("Hello, World!");