using SmartBook.Database.Data;
using SmartBook.Database.Models;

namespace SmartBook.Api.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any specific methods for Genre entity here
    }
}
