using SmartBook.Database.Data;
using SmartBook.Database.Models;

namespace SmartBook.Api.Repositories
{
    public class ReadingProgressRepository : Repository<ReadingProgress>, IReadingProgressRepository
    {
        public ReadingProgressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any specific methods for ReadingProgress entity here
    }
}
