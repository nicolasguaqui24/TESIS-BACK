namespace KioscoAPI.DTOs
{
    
        public class ClienteDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }
            public bool Activo { get; set; }
            public decimal Deuda { get; set; }
            public string? Observaciones { get; set; }
            public string? Direccion { get; set; }
            public string? TipoCliente { get; set; }
        }
    }

