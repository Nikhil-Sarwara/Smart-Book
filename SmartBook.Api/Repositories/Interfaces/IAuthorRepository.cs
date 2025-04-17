using SmartBook.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBook.Api.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(int bookId);
        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
    }
}

