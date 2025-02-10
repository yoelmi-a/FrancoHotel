using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class RolUsuario : BaseEntity<int>
    {
        [Column("IdRolUsuario")]
        [Key]
        public override int Id { get; set; }
        public string? Descripcion { get; set; }
        public BaseEstadoYFecha EstadoYFecha { get; set; } = new BaseEstadoYFecha();
    }
}