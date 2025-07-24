using System.ComponentModel.DataAnnotations;

namespace KioscoAPI.Models
{
    public class Cliente
    {
    
        [Key]
        public int id{get; set;}
    public string nombre {get; set;}
    public string telefono {get; set;}
    public string email {get; set;}
    public bool activo {get; set;}
    public decimal deuda { get; set; }
    public DateTime? fecha_alta { get; set; }
    public DateTime? fecha_baja { get; set; }
    public string? observaciones { get; set; }
    public string? direccion { get; set; }
    public string? tipo_cliente { get; set; } //Cuesta pagar o paga altoque
    

    public ICollection<PagoFiado> PagosFiado { get; set; } = new List<PagoFiado>();
        

            




}

}
