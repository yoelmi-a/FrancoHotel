namespace FrancoHotel.Application.Dtos.ClienteDtos
{
    internal class RemoveClienteDtos : DtoBase
    {
        public int IdCliente { get; set; }
        public bool Borrado { get; set; }
    }
}
