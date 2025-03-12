namespace FrancoHotel.Application.Dtos.ServiciosDto
{
    public class ServiciosDto : DtoBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
    }
}
