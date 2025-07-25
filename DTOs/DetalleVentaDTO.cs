using KioscoAPI.Controllers;
using KioscoAPI.Models;
using KioscoAPI.Data;
namespace KioscoAPI.DTOs
{
    public class DetalleVentaDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

   
}
