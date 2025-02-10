using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Tarifas : BaseEntity<int>
    {
        [Column("IdTarifa")]
        [Key]
        public override int Id { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public float Descuento { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}