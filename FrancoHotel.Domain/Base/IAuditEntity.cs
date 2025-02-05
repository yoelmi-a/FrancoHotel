namespace FrancoHotel.Domain.Base
{
    public interface IAuditEntity
    {
        public bool? Estado { get; set; } 
        public DateTime? FechaCreacion { get; set; }
    }
}
