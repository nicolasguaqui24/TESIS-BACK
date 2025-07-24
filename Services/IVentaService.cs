using KioscoAPI.DTOs;
using KioscoAPI.Models;
using System.Threading.Tasks;

namespace KioscoAPI.Services
{
    public interface IVentaService
    {
        Task<Venta> CrearVentaDesdeDTOAsync(VentaDTO dto);
        // Si luego agregas más métodos públicos al servicio, los defines aquí
    }
}