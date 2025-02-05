using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;
using Microsoft.VisualBasic;

namespace FrancoHotel.Domain.Entities
{
    public sealed class RolUsuario : BaseEntity<int>, IAuditEntity
    {
        [Column("IdRolUsuario")]
        [Key]
        public override int Id { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public RolUsuario(string descripcion)
        {
            this.Descripcion = descripcion;
            Estado = false;
            FechaCreacion = null;
        }
        public RolUsuario(int id, string descripcion, bool estado, DateTime fechaCreacion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            Estado = estado;
            FechaCreacion = fechaCreacion;
        }
    }
}
