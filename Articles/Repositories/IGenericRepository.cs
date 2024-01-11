using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetAsync(int id);

        IQueryable<T> Query();

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<List<T>> GetAllAsync();
    }
}