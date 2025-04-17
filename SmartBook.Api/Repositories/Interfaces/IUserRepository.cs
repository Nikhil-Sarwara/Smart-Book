using SmartBook.Database.Models;
using System.Threading.Tasks;

namespace SmartBook.Api.Repositories
{
    public interface IUserRepository : IRepository<UserR>
    {
        // Add any specific methods for UserR entity here if needed
    }
}
