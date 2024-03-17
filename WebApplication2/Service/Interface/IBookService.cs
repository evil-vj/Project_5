using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Service.Interface
{
    public interface IBookService
    {
        Task<dynamic> GetBooksSortedByPublisher();
        Task<dynamic> GetBooksSortedByAuthor();
        Task<dynamic> GetBookByPrcPublisher();
        Task<dynamic> GetBookByPrcAuthor();
        Task<dynamic> GetBookPrices();
        Task<dynamic> SaveBooksToDatabase(List<Book> books);
    }
}
