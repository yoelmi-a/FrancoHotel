using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace FrancoHotel.Domain.Base
{
    [Owned]
    public sealed class BaseEstadoYFecha
    {
        [Column("Estado")]
        public bool? Estado { get; set; }

        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }
    }
}