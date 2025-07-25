using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models
    {
        public class Venta
        {
        [Key]
            public int id{get; set;}
            public DateTime fecha {get; set;}
            public decimal total {get; set;}
            public string tipo_venta{get; set;} //fiado o no
            public decimal saldo_pendiente{get; set;}
            public DateTime? fecha_pago_pactado{get; set;}
        public bool? ajustar_precio_al_pago { get; set; }
        public string? observaciones { get; set; } // Observaciones de la venta, opcional
        public string? estado { get; set; } // Estado de la venta (Ej: "Pendiente", "Pagada", "Cancelada")

        // FK a Cliente
        public int id_cliente { get; set; }
        [ForeignKey("id_cliente")]
        public Cliente Cliente { get; set; }
        // FK a Usuario
        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario Usuario { get; set; }
        // Colección de detalles de venta
        public int? id_cuenta { get; set; } // FK a Cuenta, puede ser nulo si no aplica
        [ForeignKey("id_cuenta")]
        public Cuenta Cuenta { get; set; } // Relación con Cuenta, puede ser nula si no aplica

        public ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
        public ICollection<PagoFiado> PagosFiado { get; set; } = new List<PagoFiado>();
        public ICollection<CajaMovimiento> CajaMovimiento { get; set; } = new List<CajaMovimiento>();
        public Ticket Ticket { get; set; } // Relación 1 a 1 con Ticket

    }
}
