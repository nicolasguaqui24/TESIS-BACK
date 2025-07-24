using KioscoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KioscoAPI.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task<Producto> GetByCodigoBarraAsync(long codigoBarra);
        Task AddAsync(Producto producto);
        Task UpdateAsync(Producto producto);
        Task DeleteAsync(int id);
    }
}