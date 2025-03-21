namespace FrancoHotel.Application.Dtos.ClienteDtos
{
    public class ClienteDtos : DtoBase
    {
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }
    }
}
