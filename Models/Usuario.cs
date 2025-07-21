using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KioscoAPI.Models
{
    public class Usuario
    {
        [Key]
    public int id { get; set; }
    public string nombre { get; set; }
    public string usuario { get; set; }
    public bool activo { get; set; }
    public string rol { get; set; }   
    public string password_hash { get; set; }

        //Navegacion a permisos
    public ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

        // Navegacion a ventas 
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
         
        //Navegacion para caja
        public ICollection<CajaMovimiento> CajaMovimiento { get; set; } = new List<CajaMovimiento>();
        

    }
}
    