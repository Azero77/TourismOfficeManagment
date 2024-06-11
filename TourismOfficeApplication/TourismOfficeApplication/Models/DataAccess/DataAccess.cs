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
using System.Windows.Media.Animation;

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
        public async Task<IEnumerable<Client>> GetClients(string? SearchQuery) 
        {
            string query = "SELECT * FROM Clients WHERE FirstName LIKE @name";
            object param = new { name =  SearchQuery + "%"};
            var result = await RunQuery<Client>(query, param);
            return (IEnumerable<Client>) result;
        }
        public async Task<IEnumerable<Client>> GetClients(string? SearchQuery, string propertyName = "FirstName")
        {
            if (SearchQuery is null)
                return await GetClients();
            PropertyInfo? Property = typeof(Client).GetProperty(propertyName);
            string query;
            object param;
            if (Property?.PropertyType == typeof(string))
            {
                query = $"SELECT * FROM Clients WHERE {propertyName} LIKE @value";

                param = new { value = SearchQuery + "%" };
            }
            else
            {
                query = $"SELECT * FROM Clients WHERE {propertyName} = {SearchQuery}";
                
                if (long.TryParse(SearchQuery,out _)) 
                {
                    param = new {value = SearchQuery };
                }
                else
                {
                    throw new InvalidDataException();
                }
            }
            
            var result = await RunQuery<Client>(query, param);
            return (IEnumerable<Client>)result;
            throw new Exception(propertyName + "Is not a valid Property");
        }



        //RunQuery To Return object of type T
        //if type is int then Execute method is invoked
        public async Task<object> RunQuery<T>(string query, object? param)
        {
            OleDbConnection sqlConnection = GetConnection();
            object result = new();
            await sqlConnection.OpenAsync();

            //Execute Command
            
            try
            {
                if (typeof(T) == typeof(int))
                {
                    result = await sqlConnection.ExecuteAsync(query, param);
                }
                else
                    result = await sqlConnection.QueryAsync<T>(query, param);

            }
            catch (Exception e)
            {
                //TODO
                MessageBox.Show("Something Went Wrong Please Try Again \n" + e.Message);
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }

            return result;
        }

        public int GetCount(string tableName) 
        {
            string query = $"SELECT Count(*) FROM {tableName}";
            OleDbConnection oleDbConnection = GetConnection();
            oleDbConnection.Open();
            int result = 0;
            try
            {
                result =
                    oleDbConnection.ExecuteScalar<int>(query);

            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                oleDbConnection.Close();
            }
            return result;
        }

        public async Task<IEnumerable<T>> FetchRange<T>(
                                            string tableName,
                                            int offSet = 0,
                                            int limit = 10
                                            )
        {
            string query = $@"
        SELECT * FROM (
            SELECT TOP {limit} * FROM (
                SELECT TOP {offSet + limit} * FROM {tableName} ORDER BY ID
            ) AS T1
            ORDER BY ID DESC
        ) AS T2
        ORDER BY ID;";
            object param = new
            {
                offSet = offSet,
                limit = limit
            };
            try
            {
                return (IEnumerable<T>) await RunQuery<T>(query, param);

            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<IEnumerable<T>> RunQuery<T>(string tableName) 
        {
            OleDbConnection sqlConnection = GetConnection();
            IEnumerable<T> result = Enumerable.Empty<T>();
            await sqlConnection.OpenAsync();

            //Execute Command

            try
            {
                string query = $"SELECT * FROM {tableName}";
                result = await Task.Run(() =>
                sqlConnection.Query<T>(query, buffered: false));

            }
            catch (Exception)
            {
                //TODO
                MessageBox.Show("Something Went Wrong Please Try Again");
            }
            finally
            {
                await sqlConnection.CloseAsync();
            }

            return result;
        }

        public async Task<IEnumerable<T>> RunQuery<T>(string tableName,
                                                    Func<T,bool> predicate
                                                    )
        {
            OleDbConnection sqlConnection = GetConnection();
            IEnumerable<T> result = Enumerable.Empty<T>();
            await sqlConnection.OpenAsync();

            //Execute Command

            try
            {
                string query = $"SELECT * FROM {tableName}";
                result = await Task.Run(() =>
                sqlConnection
                .Query<T>(query, buffered: false)
                .Where(predicate));

            }
            catch (Exception)
            {
                //TODO
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
