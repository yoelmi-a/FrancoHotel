using FrancoHotel.Domain.Base;

namespace FrancoHotel.WedApi.Models.RecepcionModels
{
    public class PostRecepcionModel
    {
        public int Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public decimal? PrecioInicial { get; set; }
        public decimal? Adelanto { get; set; }
        public decimal? PrecioRestante { get; set; }
        public decimal? TotalPagado { get; set; }
        public decimal? CostoPenalidad { get; set; }
        public string? Observacion { get; set; }
        public EstadoReserva Estado { get; set; }
        public int? CantidadPersonas { get; set; }
        public int? IdServicioPorCategoria { get; set; }
        public decimal? PrecioServiciosExtra { get; set; }
    }
}
