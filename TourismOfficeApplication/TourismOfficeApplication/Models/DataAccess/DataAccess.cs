using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dapper;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Reflection;
using System.Collections;
using System.IO;
using System.Data;
using System.Threading;
using System.Windows.Navigation;

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
        
        public async Task<IEnumerable<Client>> GetClients(int limit,int offSet)
        {
            //string query = "SELECT * FROM Clients";
            var query = @$"
                SELECT * FROM (
                    SELECT TOP {limit} * FROM (
                        SELECT TOP {limit + offSet} *
                        FROM Clients
                    ) AS t1
                    ORDER BY Id DESC
                ) AS t2
                ORDER BY Id";
            var result = await RunQuery<Client>(query, new { a = 30 });
            
            
            return (IEnumerable<Client>)result;
        }
        public async Task<IEnumerable<Client>> GetClients(
            string? searchQuery,
            int limit,
            int offset,
            string propertyName = "FirstName"
            )
        {
            string query;
            object param;
            string condition;
            //Evaluate condiont and param depend on the type of the search query and the value
            Evaluate(searchQuery, propertyName, out condition, out param);
                
            
            query =
                "SELECT * FROM ("+
              $"SELECT TOP {limit} * FROM " +
              $"(SELECT TOP {limit + offset} * FROM Clients {condition} ORDER BY ID) AS t1 " +
              $"ORDER BY ID DESC) as t2 ORDER BY ID";

            var result = await RunQuery<Client>(query, param);
            
            return (IEnumerable<Client>)result;
        }

        public async Task<int> GetCountClient(string? searchQuery, string propertyName = "FirstName") 
        {
            string query = $"SELECT Count(*) FROM Clients";
            object param;
            string where;
            
            Evaluate(searchQuery, propertyName, out where, out param);
            query += where;
            try
            {
                var result = await RunQuery<int>(query,param,true);
                return ((IEnumerable<int>)result).First();
            }
            catch (Exception)
            {

                throw;
            }

        }




        //RunQuery To Return object of type T
        //if type is int then Execute method is invoked
        public async Task<object> RunQuery<T>(string query, object? param, bool FetchCount = false)
        {
            OleDbConnection sqlConnection = GetConnection();
            object result = new();
            await sqlConnection.OpenAsync();
            //Execute Command

            try
            {
                if (typeof(T) == typeof(int) && !FetchCount)
                {
                    result = await sqlConnection.ExecuteAsync(query, param);
                }
                else
                    result = await sqlConnection.QueryAsync<T>(query, param);

            }
            catch (Exception e)
            {
                //TODO
                MessageBox.Show("Something Went Wrong Please Try Again \n\r" + e.Message);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }

            return result;
        }


        private void Evaluate(
                            string? searchQuery,
                            string propertyName,
                            out string where, 
                            out object param) 
        {
            if (searchQuery is not null)
            {
                PropertyInfo? Property = typeof(Client).GetProperty(propertyName);
                if (Property?.PropertyType == typeof(string))
                {
                    where = $" WHERE {propertyName} LIKE @value";

                    param = new { value = searchQuery + "%" };
                    return;
                }
                else
                {
                    where = $" WHERE {propertyName} = {searchQuery}";

                    if (long.TryParse(searchQuery, out _))
                    {
                        param = new { value = searchQuery };
                        return;
                    }
                    else
                    {
                        throw new InvalidDataException();
                    }
                }
            }
            //else
            where = string.Empty;
            param = new object();
        }

    }
}
