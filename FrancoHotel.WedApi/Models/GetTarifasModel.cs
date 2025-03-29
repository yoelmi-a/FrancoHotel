using FrancoHotel.Domain.Base;

namespace FrancoHotel.WedApi.Models
{
    public class GetTarifasModel
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCategoria { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? PrecioPorNoche { get; set; }
        public decimal? Descuento { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }
}
