
namespace FrancoHotel.Application.Dtos.TarifasDto
{
    public class TarifasDto : DtoBase
    {
        public int? IdCategoria { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
