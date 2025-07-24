using KioscoAPI.Data;
using KioscoAPI.Models;
using KioscoAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KioscoAPI.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly KioscoDbContext _context;

        public VentaRepository(KioscoDbContext context)
        {
            _context = context;
        }

        public async Task<Venta> CrearVentaAsync(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return venta;
        }

        public async Task<List<Venta>> ObtenerTodasAsync()
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.DetalleVenta)
                    .ThenInclude(d => d.Producto)
                .ToListAsync();
        }

        public async Task<Venta?> ObtenerPorIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Usuario)
                .Include(v => v.DetalleVenta)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(v => v.id == id);
        }

        public async Task<bool> CancelarVentaAsync(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null) return false;

            venta.estado = "Cancelada";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
