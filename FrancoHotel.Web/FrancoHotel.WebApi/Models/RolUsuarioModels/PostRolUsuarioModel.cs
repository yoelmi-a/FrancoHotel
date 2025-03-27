namespace FrancoHotel.WebApi.Models.RolUsuarioModels
{
    public class PostRolUsuarioModel
    {
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
