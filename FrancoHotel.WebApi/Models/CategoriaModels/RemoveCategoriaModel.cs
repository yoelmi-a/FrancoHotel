namespace FrancoHotel.WebApi.Models.CategoriaModels
{
    public class RemoveCategoriaModel
    {
        public int Id { get; set; }
        public bool Borrado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
