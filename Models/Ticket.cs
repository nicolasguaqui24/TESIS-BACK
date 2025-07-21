using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models
{

    public class Ticket
    {
        public int Id { get; set; }
        public string NombreComercio { get; set; } // opcional, configurable
        public DateTime Fecha { get; set; }
        public String Items { get; set; }
        public decimal Total { get; set; }
        public decimal Impuestos { get; set; }
        public string MetodoPago { get; set; }
        public string NumeroTransaccion { get; set; } // opcional, si aplica

        public int id_venta { get; set; }
        [ForeignKey("id_venta")]
        public Venta Venta { get; set; } // Relación con la venta asociada
    }
}