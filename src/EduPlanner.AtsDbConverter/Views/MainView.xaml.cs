using System.Windows;
using System.Windows.Controls;
using EduPlanner.AtsDbConverter.Helpers;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace EduPlanner.AtsDbConverter.Views;

public partial class MainView : UserControl
{
    private readonly IServiceProvider _serviceProvider;
    
    public MainView(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
        DbHost.Text = "localhost";
        DbPort.Text = "3306";
        DbLogin.Text = "root";
        DbPassword.Password = "root123";
        DbName.Text = "ats";
    }

    private void CheckConnection(object sender, RoutedEventArgs e)
    {
        if (!CheckTextBoxes()) return;
        
        var service = _serviceProvider.GetService<MainWindow>();
            
        DbHelper mySqlHelper = new DbHelper(DbHost.Text,DbName.Text,DbLogin.Text,DbPassword.Password.ToString(),DbPort.Text);
        if (!mySqlHelper.IsConnection) return;
        service.ImportConfiguration.IsEnabled = true;
        service.TabControl.SelectedIndex = 1;
        DynamicConnectionString.Value = mySqlHelper.ConnectionString;;
    }
    
    public bool CheckTextBoxes()
    {
        if (string.IsNullOrWhiteSpace(DbHost.Text) ||
            string.IsNullOrWhiteSpace(DbName.Text) ||
            string.IsNullOrWhiteSpace(DbLogin.Text) ||
            string.IsNullOrWhiteSpace(DbPassword.Password) ||
            string.IsNullOrWhiteSpace(DbPort.Text))
        {
            MessageBox.Show("Wypełnij wszystkie pola", "Wystąpił błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return true;
    }

}