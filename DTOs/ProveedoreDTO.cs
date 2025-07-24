namespace KioscoAPI.DTOs
{
    public class ProveedoreDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string CBU { get; set; }
        public int deuda { get; set; }

        public string direccion { get; set; }  // <- Agrega esta propiedad
        public string email { get; set; }
        public bool activo { get; set; }



    }

    public class ProveedoreCreateDTO
    {
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string CBU { get; set; }
        public int deuda { get; set; }
            public string Direccion { get; set; }  // <- Agrega esta propiedad
        public string Email { get; set; }
        public bool Activo { get; set; }

    }
}