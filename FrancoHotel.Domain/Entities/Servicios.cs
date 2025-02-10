using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Servicios : BaseEntity<short>
    {
        [Column("IdServicio")]
        [Key]
        public override short Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
