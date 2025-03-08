using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrancoHotel.Domain.Entities
{
    public sealed class CategoriaServicios
    {
        [Column("IdCategoriaServicio")]
        [Key]
        public int IdCategoriaServicio { get; set; }
        public int IdCategoria { get; set; }
        public int IdServicio { get; set; }
        public int IdCombinacionServicios { get; set; }
    }
}
