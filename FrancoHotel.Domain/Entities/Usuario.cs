
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Usuario : Person<int>
    {
        [Column("IdUsuario")]
        [Key]
        public override int Id { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Clave { get; set; }
        public BaseEstadoYFecha EstadoYFecha { get; set; } = new BaseEstadoYFecha();
    }
}