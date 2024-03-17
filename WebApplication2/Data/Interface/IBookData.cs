using System.Data;
using System.Threading.Tasks;

namespace WebApplication2.Data.Interface
{
    public interface IBookData
    {
        Task<dynamic> GetBooksSortedByPublisher();
        Task<dynamic> GetBooksSortedByAuthor();
        Task<dynamic> GetBookByPrcPublisher();
        Task<dynamic> GetBookByPrcAuthor();
        Task<dynamic> GetBookPrices();
        Task<dynamic> SaveBooksToDatabase(DataTable dataTable);

    }
}
