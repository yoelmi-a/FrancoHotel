using FrancoHotel.Domain.Base;

namespace FrancoHotel.Application.Dtos.HabitacionDtos
{
    public class HabitacionDto : DtoBase
    {
        public string Numero { get; set; }
        public string Detalle { get; set; }
        public int? IdEstadoHabitacion { get; set; }
        public int? IdPiso { get; set; }
        public int? IdCategoria { get; set; }
        public bool? Estado { get; set; }
        public int? Capacidad { get; set; }
    }
}
