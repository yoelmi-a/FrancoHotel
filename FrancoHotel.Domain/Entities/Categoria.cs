using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Categoria : BaseEntity<int>
    {
        [Column("IdCategoria")]
        [Key]
        public override int Id { get; set;}
        public string? Descripcion { get; set;}
        public short IdServicio { get; set;}
        public BaseEstadoYFecha EstadoYFecha { get; set;} = new BaseEstadoYFecha();
    }
}
