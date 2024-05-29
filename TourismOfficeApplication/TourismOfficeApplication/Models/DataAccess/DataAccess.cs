using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dapper;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace TourismOfficeApplication.Models.DataAccess
{
    public class DataAccess
    {
        private string _connectionString = string.Empty;

        public string ConnectionString
        {
            get => _connectionString;
            set =>
            _connectionString = value;
        }

        public DataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private OleDbConnection GetConnection()
        {
            OleDbConnection sqlConnection = new OleDbConnection(ConnectionString);
            return sqlConnection;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            string query = "SELECT * FROM Clients";
            var result = await RunQuery<Client>(query, null);
            return (IEnumerable<Client>)result;
        }

        //RunQuery To Return object of type T
        //if type is int then Execute method is invoked
        public async Task<object> RunQuery<T>(string query, object? param)
        {
            OleDbConnection sqlConnection = GetConnection();
            object result;
            await sqlConnection.OpenAsync();

            if (typeof(T) == typeof(int))
            { }

            try
            {
                result = await sqlConnection.QueryAsync<T>(query, param);

            }
            catch (Exception)
            {
                //TODO
                result = new();
                MessageBox.Show("Something Went Wrong Please Try Again");
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }

            return result;
        }

    }
}
