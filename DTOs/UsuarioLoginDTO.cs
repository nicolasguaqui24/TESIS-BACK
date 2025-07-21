using System;

namespace KioscoAPI.DTOs
{
	
        public class UsuarioLoginDTO
        {
            public string Usuario { get; set; }
            public string Password { get; set; }
        }
    public class RegisterRequest
    {
      
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

    }
    public class UsuarioProfileDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }


}
