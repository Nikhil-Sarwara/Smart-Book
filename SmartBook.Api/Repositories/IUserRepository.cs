using SmartBook.Database.Models;
using System.Threading.Tasks;

namespace SmartBook.Api.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        // Add any specific methods for User entity here if needed
    }
}
