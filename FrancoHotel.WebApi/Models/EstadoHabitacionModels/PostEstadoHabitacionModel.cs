namespace FrancoHotel.WebApi.Models.EstadoHabitacionModels
{
    public class PostEstadoHabitacionModel
    {
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
