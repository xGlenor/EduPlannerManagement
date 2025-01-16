using System.Windows;
using System.Windows.Controls;
using EduPlanner.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace EduPlanner.AtsDbConverter.Views;

public partial class ConverterView : UserControl
{
    private readonly IServiceProvider _serviceProvider;
    
    public ConverterView(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    public void AddItem(string item)
    {
        ListInformation.Items.Add(item);
    }
    
    private void ConvertDatabase(object sender, RoutedEventArgs e)
    {
        //var converterService = _serviceProvider.GetService<ConverterService>();
        //converterService.Convert();

        var dbContext = _serviceProvider.GetRequiredService<OldDbContext>();
        var courses = dbContext.Courses.Select(c => new {c.Name, c.Shortcut}).ToList();

        foreach (var item in courses)
        {
            AddItem($"{item.Name} - {item.Shortcut}");
        }

    }
}