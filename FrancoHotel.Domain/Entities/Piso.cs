using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Piso : BaseEntity<int>, IAuditEntity
    {
        [Column("IdPiso")]
        [Key]
        public override int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public Piso(string descripcion)
        {
            this.Descripcion = descripcion;
            Estado = false;
            FechaCreacion = null;
        }

        public Piso(string descripcion, int id, DateTime fechaCreacion, bool estado)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.FechaCreacion= fechaCreacion;
        }

    }
}
