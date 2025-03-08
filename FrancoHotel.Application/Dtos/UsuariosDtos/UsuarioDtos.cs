namespace FrancoHotel.Application.Dtos.UsuariosDtos
{
    public class UsuarioDtos : DtoBase
    {
        public int? IdUsuario { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Clave { get; set; }
        public bool? Estado { get; set; }
    }
}
