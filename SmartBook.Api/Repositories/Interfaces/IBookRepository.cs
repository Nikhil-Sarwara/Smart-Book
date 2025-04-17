using SmartBook.Database.Models;
using System.Threading.Tasks;

namespace SmartBook.Api.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        // Add any specific methods for BookR entity here if needed
    }
}
