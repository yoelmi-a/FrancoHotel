using FrancoHotel.Domain.Base;

namespace FrancoHotel.WedApi.Models
{
    public class RemoveTarifasModel
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
