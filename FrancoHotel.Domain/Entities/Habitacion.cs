using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Habitacion : BaseEntity<int>
    {
        [Column("IdHabitacion")]
        [Key]

        public override int Id { get; set; }
        public string? Numero { get; set; }
        public string? Detalle { get; set; }
        public int? IdEstadoHabitacion { get; set; }
        public int? IdPiso { get; set; }
        public int? IdCategoria { get; set; }
        public BaseEstadoYFecha EstadoYFecha { get; set; } = new BaseEstadoYFecha(); //Composicion
        public int? Capacidad { get; set; }
    }
}
