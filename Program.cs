using System;
using static System.Console;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

namespace MyConnectionFactory
{
    // A list of possible providers.
    enum DataProvider
    { SqlServer, OleDb, Odbc, None }

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Very Simple Connection Factory *****\n");
            // Get a specific connection.
            IDbConnection myConnection = GetConnection(DataProvider.SqlServer);
            WriteLine($"Your connection is a {myConnection.GetType().Name}");
            // Open, use and close connection...
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
