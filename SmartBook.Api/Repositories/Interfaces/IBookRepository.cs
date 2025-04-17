using SmartBook.Api.Repositories;
using SmartBook.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBook.Api.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        // Add any book-specific methods here if needed, considering the new model
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<Book>> GetBooksByGenreAsync(int genreId);
        Task<IEnumerable<Book>> GetBooksByPublisherAsync(int publisherId);
        Task<Book?> GetBookByISBNAsync(string isbn);
    }
}