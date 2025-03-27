namespace FrancoHotel.WebApi.Models.UsuarioModels
{
    public class RemoveUsuarioModel
    {
        public int IdUsuario { get; set; }
        public bool Borrado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
