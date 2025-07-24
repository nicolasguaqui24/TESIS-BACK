using KioscoAPI.Models;

namespace KioscoAPI.Repositories
{
    public interface IVentaRepository
    {
        Task<Venta> CrearVentaAsync(Venta venta);
        Task<List<Venta>> ObtenerTodasAsync();
        Task<Venta?> ObtenerPorIdAsync(int id);
        Task<bool> CancelarVentaAsync(int id);
    }
}
