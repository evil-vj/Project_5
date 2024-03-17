using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Interface;
using WebApplication2.Models;

namespace WebApplication2.Data.DataManager
{
    public class BookData : IBookData
    {

        private static readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Temp;Integrated Security=true;";

        public async Task<dynamic> GetBooksSortedByAuthor()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var books = connection.Query<Book>("SELECT * FROM Books ORDER BY publisher, authorLastName, authorFirstName, title").ToList();
                    return books;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> GetBooksSortedByPublisher()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var books = connection.Query<Book>("SELECT * FROM Books ORDER BY authorLastName, authorFirstName, title").ToList();
                    return books;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> GetBookByPrcAuthor()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    DynamicParameters par = new DynamicParameters();
                    var books = await connection.QueryAsync<Book>(sql: "prcGetBooksDataByAuthor", param: par, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    return books;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> GetBookPrices()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    dynamic ex = new ExpandoObject();
                    await connection.OpenAsync();
                    ex.TotalPrice = connection.Query<Int32?>("SELECT SUM(price) AS totalPrice FROM Books");
                    return ex;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> GetBookByPrcPublisher()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    DynamicParameters par = new DynamicParameters();
                    var books = await connection.QueryAsync<Book>(sql: "prcGetBooksDataByPublisher", param: par, commandType: CommandType.StoredProcedure, commandTimeout: 300);
                    return books;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> SaveBooksToDatabase(DataTable dataTable)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = "books";
                        bulkCopy.WriteToServer(dataTable);
                    }
                    
                    return "Books saved successfully.";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
