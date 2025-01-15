using System.Windows;
using System.Windows.Controls;

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
    }
}