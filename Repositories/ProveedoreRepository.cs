using KioscoAPI.Data;
using KioscoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KioscoAPI.Repositories
{
    public class ProveedoreRepository : IProveedoreRepository
    {
        private readonly KioscoDbContext _context;

        public ProveedoreRepository(KioscoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedore>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedore?> GetByIdAsync(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task<Proveedore> CreateAsync(Proveedore proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }

        public async Task UpdateAsync(Proveedore proveedor)
        {
            _context.Entry(proveedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Proveedore proveedor)
        {
            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
        }
    }
}