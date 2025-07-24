using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models
{
    public class Cuenta
    {
       
        
            public int Id { get; set; }
            
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaCierre { get; set; } // Puede ser nulo si la cuenta está abierta
        public string Estado { get; set; } = "Abierta"; // "Abierta", "Cerrada", etc.
        public string Observaciones { get; set; } // Observaciones sobre la cuenta, opcional

        public decimal Saldo { get; set; }

        // Relación con Cliente
        public int id_cliente { get; set; }

        [ForeignKey("id_cliente")] // indica que Cliente usa la FK id_cliente
        public Cliente Cliente { get; set; }
        // Relación con Usuario
        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")] // indica que Usuario usa la FK id_usuario
        public Usuario Usuario { get; set; }


        public ICollection<PagoFiado> Pagos { get; set; } = new List<PagoFiado>();
        public ICollection<Venta> VentasFiadas { get; set; } = new List<Venta>();
    }

    
}
