namespace FrancoHotel.Models.Models
{
    internal class TarifasModel
    {
        public int IdTarifas { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public float Descuento { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
