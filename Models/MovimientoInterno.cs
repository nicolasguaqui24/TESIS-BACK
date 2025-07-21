using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KioscoAPI.Models
{

    public class MovimientoInterno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; } // "Consumo", "Rotura", etc.
        /*
        public List<DetalleMovimientoInterno> Detalles { get; set; } 
        */

        public string UsuarioResponsable { get; set; }

        // public ICollection<DetalleMovimientoInterno> Detalles { get; set; } = new List<DetalleMovimientoInterno>();



    }

}