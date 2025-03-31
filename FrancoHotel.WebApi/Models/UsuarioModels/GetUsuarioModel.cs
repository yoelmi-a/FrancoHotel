namespace FrancoHotel.WebApi.Models.UsuarioModels
{
    public class GetUsuarioModel
    {
        public int IdUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Clave { get; set; }
        public bool? Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
