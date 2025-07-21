using KioscoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using KioscoAPI.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace KioscoAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}