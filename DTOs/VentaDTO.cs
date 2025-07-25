using KioscoAPI.DTOs;
namespace KioscoAPI.DTOs
{
    public class VentaDTO//DTO PARA CREAR VENTA
    {
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal? Total { get; set; }
        public string TipoVenta { get; set; } = "Contado"; // "Contado" o "Fiado"
      
        public DateTime? FechaPagoPactado { get; set; }
        public string? Observaciones { get; set; }
        public string? Estado { get; set; }

        public int id_cliente { get; set; }
        public int id_usuario { get; set; }
        public int id_cuenta { get; set; }

        public List<DetalleVentaDTO> Detalles { get; set; } 
    }
    public class VentaDetalladaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string TipoVenta { get; set; }
        public string? Estado { get; set; }
        public string? Observaciones { get; set; }

        public string ClienteNombre { get; set; }
        public string UsuarioNombre { get; set; }

        // Info de la cuenta (si la tiene)
        public int id_cuenta { get; set; }
        public string? CuentaEstado { get; set; }
        public decimal CuentaSaldo { get; set; }


        public List<DetalleVentaDTO> Detalles { get; set; }

       // public TicketDTO Ticket { get; set; } si lo necesitás mostrar
    }

}
