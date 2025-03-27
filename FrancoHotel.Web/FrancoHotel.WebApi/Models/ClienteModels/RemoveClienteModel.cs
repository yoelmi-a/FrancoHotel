namespace FrancoHotel.WebApi.Models.ClienteModels
{
    public class RemoveClienteModel
    {
        public int IdCliente { get; set; }
        public bool Borrado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
