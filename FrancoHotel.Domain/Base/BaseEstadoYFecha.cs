using Microsoft.EntityFrameworkCore;

namespace FrancoHotel.Domain.Base
{
    [Owned]
    public sealed class BaseEstadoYFecha
    {
        public bool? Estado { get; set; } 
        public DateTime? FechaCreacion { get; set; }
    }
}
