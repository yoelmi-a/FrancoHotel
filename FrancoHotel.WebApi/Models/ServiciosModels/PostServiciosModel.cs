namespace FrancoHotel.WebApi.Models.ServiciosModels
{
    public class PostServiciosModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
