using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using KioscoAPI.Models;

namespace KioscoAPI.Models
{

    public class MovimientoInterno
    {
   
        public int id { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public string motivo { get; set; } // "Consumo", "Rotura", etc.
        public string? Observaciones { get; set; }

        // Relación con Usuario
        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")] // indica que Usuario usa la FK id_usuario
        public Usuario Usuario { get; set; }
        public ICollection<DetalleMovimientoInterno> Detalles { get; set; } = new List<DetalleMovimientoInterno>();



    }

}