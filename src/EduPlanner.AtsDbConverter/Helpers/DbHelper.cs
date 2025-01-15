using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace EduPlanner.AtsDbConverter.Helpers;

public class DbHelper
{
    private MySqlConnection _mySqlConnection;
    private MySqlConnectionStringBuilder _mySqlConnectionStringBuilder;
    
    public DbHelper(string host, string database, string username, string password, string port)
    {
        _mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder
        {
            Server = host,
            Database = database,
            UserID = username,
            Password = password,
            Port = uint.Parse(port)
        };
        
        _mySqlConnection = new MySqlConnection(_mySqlConnectionStringBuilder.ConnectionString);
    }
    public bool IsConnection
    {
        get
        {
            try
            {
                _mySqlConnection.Open();
                if (_mySqlConnection.State.Equals(ConnectionState.Open))
                {
                    MessageBox.Show($"Gratulację, udało się!\n{_mySqlConnection.ServerVersion}", "Success MySQL");
                    _mySqlConnection.Close();
                    return true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Message: {exception.Message}\nStackTrace: {exception.StackTrace}", "Error");
                Console.WriteLine($"Message: {exception.Message}\nStackTrace: {exception.StackTrace}");

                return false;
            }

            return false;
        }
    }
    
    public MySqlConnection GetConnection()
    {
        return _mySqlConnection;
    }

    public string ConnectionString => _mySqlConnectionStringBuilder.ConnectionString;
}