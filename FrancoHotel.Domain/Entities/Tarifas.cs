using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    internal sealed class Tarifas : BaseEntity<int>
    {
        [Key]
        [Column("IdTarifa")]
        public override int Id { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public float PrecioPorNoche { get; set; }
        public float Descuento { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
