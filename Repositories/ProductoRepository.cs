using KioscoAPI.Data;
using KioscoAPI.Models;
using KioscoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KioscoAPI.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly KioscoDbContext _context;

        public ProductoRepository(KioscoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedore)
                .ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedore)
                .FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Producto> GetByCodigoBarraAsync(long codigoBarra)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedore)
                .FirstOrDefaultAsync(p => p.codigo_barra == codigoBarra);
        }

        public async Task AddAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}