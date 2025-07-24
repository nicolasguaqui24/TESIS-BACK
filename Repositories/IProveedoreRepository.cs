using KioscoAPI.Models;

namespace KioscoAPI.Repositories
{
    public interface IProveedoreRepository
    {
        Task<IEnumerable<Proveedore>> GetAllAsync();
        Task<Proveedore?> GetByIdAsync(int id);
        Task<Proveedore> CreateAsync(Proveedore proveedor);
        Task UpdateAsync(Proveedore proveedor);
        Task DeleteAsync(Proveedore proveedor);

    }
}
