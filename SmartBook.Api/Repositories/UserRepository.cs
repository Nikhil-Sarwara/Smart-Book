using SmartBook.Database.Data;
using SmartBook.Database.Models;

namespace SmartBook.Api.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        // Implement any specific methods for User entity here
    }
}
