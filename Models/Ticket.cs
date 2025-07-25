using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KioscoAPI.Models
{

    public class Ticket
    {
        
        public int id { get; set; }
        public string nombreComercio { get; set; } // opcional, configurable
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public decimal? subtotal { get; set; }
        public decimal? impuestos { get; set; }
        public string? metodoPago { get; set; }
        public string? numeroTransaccion {    get; set; } // opcional, si aplica

        public int id_venta { get; set; }
        [ForeignKey("id_venta")]
        public Venta Venta { get; set; } // Relación con la venta asociada
    }
}