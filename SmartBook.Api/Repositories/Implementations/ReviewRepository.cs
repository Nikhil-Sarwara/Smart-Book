using SmartBook.Database.Data;
using SmartBook.Database.Models;

namespace SmartBook.Api.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any specific methods for Review entity here
    }
}
