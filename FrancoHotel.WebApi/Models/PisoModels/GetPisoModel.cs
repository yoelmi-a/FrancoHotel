namespace FrancoHotel.WebApi.Models.PisoModels
{
    public class GetPisoModel
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
