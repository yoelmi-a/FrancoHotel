using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrancoHotel.Domain.Entities
{
    public sealed class ServiciosExtra
    {
        [Column("IdServicio")]
        [Key]
        public int IdServicio { get; set; }

        [Column("IdRecepcion")]
        [Key]
        public int IdRecepcion { get; set; }
    }
}
