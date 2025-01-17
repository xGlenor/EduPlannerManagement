using System.Resources;
using System.Windows;
using System.Windows.Controls;
using EduPlanner.AtsDbConverter.Services;
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Infrastructure.Database;
using EduPlanner.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
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
        var converter = _serviceProvider.GetRequiredService<IConvertService>();
        //converterService.Convert();
        converter.Convert();
        
    }
}