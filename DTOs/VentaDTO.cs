namespace KioscoAPI.DTOs
{
    public class VentaDTO
    {
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public string TipoVenta { get; set; } = "Contado"; // "Contado" o "Fiado"
        public decimal SaldoPendiente { get; set; }
        public DateTime? FechaPagoPactado { get; set; }
        public string? Observaciones { get; set; }
        public string? Estado { get; set; }

        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdCuenta { get; set; }

        public List<DetalleVentaDTO> Detalles { get; set; } 
    }
}
