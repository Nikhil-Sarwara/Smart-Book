using SmartBook.Database.Models;
using System.Threading.Tasks;

namespace SmartBook.Api.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        // Add any specific methods for Book entity here if needed
    }
}
