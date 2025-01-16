using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Threading;
using EduPlanner.AtsDbConverter.Views;
using EduPlanner.Infrastructure;
using EduPlanner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EduPlanner.AtsDbConverter;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    [STAThread]
    public static void Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        host.Start();
        
        App app = new();
        app.InitializeComponent();
        
        app.MainWindow = host.Services.GetRequiredService<MainWindow>();
        app.MainWindow.Visibility = Visibility.Visible;
        app.Run();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
            {
            })
            .ConfigureServices((hostContext, services) =>
            {

                //
                // ADD VIEWS
                //
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainView>();
                services.AddSingleton<ConverterView>();
                    
                //
                // ADD SERVICES
                //
                services.AddInfrastructure(hostContext.Configuration);

                services.AddSingleton<Dispatcher>(_ => Current.Dispatcher);
                    
                /*services.AddDbContext<ApplicationDbContext>(opt =>
                {
                    var connectionString = hostContext.Configuration.GetConnectionString("Default");
                    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                });*/
            });
    
}