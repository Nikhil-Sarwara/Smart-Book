using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBook.Api.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id); // Changed return type to Task<T?> to handle not found scenarios
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}