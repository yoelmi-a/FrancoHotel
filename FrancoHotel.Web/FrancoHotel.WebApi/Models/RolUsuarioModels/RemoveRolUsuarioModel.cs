namespace FrancoHotel.WebApi.Models.RolUsuarioModels
{
    public class RemoveRolUsuarioModel
    {
        public int IdRolUsuario { get; set; }
        public bool Borrado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
