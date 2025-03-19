namespace FrancoHotel.Application.Dtos.UsuariosDtos
{
    public class UsuarioDtos : DtoBase
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Clave { get; set; }
        public bool? Estado { get; set; }
    }
}
