using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApplication2.Data.DataManager;
using WebApplication2.Data.Interface;
using WebApplication2.Models;
using WebApplication2.Service.Interface;

namespace WebApplication2.Service.ServiceManager
{
    public class BookService : IBookService
    {
        public IBookData bookData = new BookData();
        public async Task<dynamic> GetBooksSortedByAuthor()
        {
            try
            {
                var result = await bookData.GetBooksSortedByPublisher();
                return result;
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
                var result = await bookData.GetBooksSortedByPublisher();
                return result;
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
                var result = await bookData.GetBooksSortedByPublisher();
                return result;
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
                var result = await bookData.GetBooksSortedByPublisher();
                return result;
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
                var result = await bookData.GetBookPrices();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> SaveBooksToDatabase(List<Book> books)
        {
            try
            {
                DataTable dataTable = GetBookDataTable(books);
                var result = await bookData.SaveBooksToDatabase(dataTable);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetBookDataTable(List<Book> books)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("publisher", typeof(string));
            dataTable.Columns.Add("title", typeof(string));
            dataTable.Columns.Add("authorLastName", typeof(string));
            dataTable.Columns.Add("authorFirstName", typeof(string));
            dataTable.Columns.Add("price", typeof(decimal));

            foreach (var book in books)
            {
                dataTable.Rows.Add(book.Publisher,book.Title,book.AuthorLastName,book.AuthorFirstName,book.Price);
            }
            return dataTable;
        }
    }
}
