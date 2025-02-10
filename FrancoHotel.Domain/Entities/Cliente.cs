using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Cliente : Person<int>
    {
        [Column("IdCliente")]
        [Key]
        public override int Id { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public BaseEstadoYFecha EstadoYFecha { get; set; } = new BaseEstadoYFecha();
    }
}