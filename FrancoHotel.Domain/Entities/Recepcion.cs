using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    internal class Recepcion : BaseEntity<int>
    {
        [Column("IdRecepcion")]
        [Key]
        public override int Id { get; set; }
        public int IdCliente {  get; set; }
        public int IdHabitacion {  get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime Salida { get; set; }
        public DateTime FechaSalidaConfirmacion { get; set; }
        public float PrecioInicial { get; set; }
        public float Adelanto { get; set; }
        public float PrecioRestante { get; set; }
        public float TotalPagado { get; set; }
        public float CostoPenalidad { get; set; }
        public string Obsevacion { get; set; }
        public bool Estado { get; set; }
    }
}
