using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ConnectionClass
    {

        private readonly string _connectionString;
            private SqlConnection _connection;

            public ConnectionClass(string connectionString)
            {
                _connectionString = connectionString;
            }
         public SqlConnection Connection => _connection;
        public void OpenConnection()
            {
                _connection = new SqlConnection(_connectionString);

                try
                {
                    _connection.Open();
                    Console.WriteLine("Connection opened successfully.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL error: {ex.Message}");
                }
            }

            public void CloseConnection()
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                    Console.WriteLine("Connection closed successfully.");
                }
            }
        }
    
}
