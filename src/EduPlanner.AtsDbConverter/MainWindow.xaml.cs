using System.Windows;
using System.Windows.Controls;
using EduPlanner.AtsDbConverter.Views;
using Microsoft.Extensions.DependencyInjection;

namespace EduPlanner.AtsDbConverter;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    
    public MainWindow(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl tabControl)
        {
            var selectedTab = tabControl.SelectedItem as TabItem;
            if (selectedTab != null)
            {
                switch (selectedTab.Name)
                {
                    case "DatabaseConfiguration":
                        selectedTab.Content = _serviceProvider.GetRequiredService<MainView>();
                        break;
                    case "ImportConfiguration":
                        selectedTab.Content = _serviceProvider.GetRequiredService<ConverterView>();
                        break;
                }
            }
        }
    }
}