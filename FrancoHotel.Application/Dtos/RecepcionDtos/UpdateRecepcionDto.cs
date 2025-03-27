
namespace FrancoHotel.Application.Dtos.RecepcionDtos
{
    public class UpdateRecepcionDto : RecepcionDtos
    {
        public int Id { get; set; }
        public DateTime? FechaSalidaConfirmacion { get; set; }
    }
}
