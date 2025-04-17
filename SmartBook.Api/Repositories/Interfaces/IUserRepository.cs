using SmartBook.Database.Models;
using System.Threading.Tasks;

namespace SmartBook.Api.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByNameAsync(string name);
    }
}