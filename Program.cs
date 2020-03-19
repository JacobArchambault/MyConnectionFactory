using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using static System.Configuration.ConfigurationManager;
using static System.Console;
using static System.Enum;
namespace MyConnectionFactory
{
    // A list of possible providers.
    enum DataProvider
    { SqlServer, OleDb, Odbc, None }

    class Program
    {
        static void Main()
        {
            WriteLine("***** Very Simple Connection Factory *****\n");
            // Read the provider key.
            string dataProviderString = AppSettings["provider"];
            // Transform string to enum.
            DataProvider dataProvider;
            if (IsDefined(typeof(DataProvider), dataProviderString))
            {
                dataProvider = (DataProvider)Parse(typeof(DataProvider), dataProviderString);
                // Get a specific connection.
                IDbConnection myConnection = GetConnection(dataProvider);
                WriteLine($"Your connection is a {myConnection?.GetType().Name ?? "unrecognized type"}");
                // Open, use and close connection...
            }
            else
            {
                WriteLine("Sorry, no provider exists!");
            }
            ReadLine();
        }

        // This method returns a specific connection object based on the value of a DataProvider enum
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    connection = new OdbcConnection();
                    break;
            }
            return connection;
        }
    }
}
