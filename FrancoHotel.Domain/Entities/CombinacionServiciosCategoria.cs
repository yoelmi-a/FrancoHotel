using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrancoHotel.Domain.Entities
{
    public sealed class CombinacionServiciosCategoria
    {
        [Column("IdCombinacion")]
        [Key]
        public int IdCombinacion { get; set; }
        public int IdCategoria { get; set; }
        public decimal? Precio { get; set; }
        public bool? Estado { get; set; }
    }
}