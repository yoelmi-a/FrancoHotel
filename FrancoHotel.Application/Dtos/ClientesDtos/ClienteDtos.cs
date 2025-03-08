﻿namespace FrancoHotel.Application.Dtos.ClienteDtos
{
    public class ClienteBaseDtos : DtoBase
    {
        public int? IdCliente { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }
    }
}
