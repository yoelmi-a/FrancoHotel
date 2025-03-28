namespace FrancoHotel.WebApi.Models.EstadoHabitacionModels
{
    public class GetEstadoHabitacionModel
    {
        public int IdEstadoHabitacion { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
