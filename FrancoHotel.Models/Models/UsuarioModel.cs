 namespace FrancoHotel.Models.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int IdRolUsuario { get; set; }
        public RolUsuarioModel RolUsuario { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
