namespace FrancoHotel.WebApi.Models.ClienteModels
{
    public class PostClienteModel
    {
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
    }
}
