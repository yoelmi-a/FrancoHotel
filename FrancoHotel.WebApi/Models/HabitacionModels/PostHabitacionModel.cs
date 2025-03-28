namespace FrancoHotel.WebApi.Models.HabitacionModels
{
    public class PostHabitacionModel
    {
        public string Numero { get; set; }
        public string Detalle { get; set; }
        public int? IdEstadoHabitacion { get; set; }
        public int? IdPiso { get; set; }
        public int? IdCategoria { get; set; }
        public bool? Estado { get; set; }
        public int? Capacidad { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
