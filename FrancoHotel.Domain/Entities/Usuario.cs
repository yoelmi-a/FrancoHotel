using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Usuario : BaseEntity<int>, IAuditEntity
    {
        [Column("IdUsuario")]
        [Key]
        public override int Id { get; set; }
        public int IdRolUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public Usuario(int idRolUsuario, string nombreCompleto, string correo, string clave)
        {
            this.IdRolUsuario = idRolUsuario;
            this.NombreCompleto = nombreCompleto;
            this.Correo = correo;
            this.Clave = clave;
            Estado = false;
            FechaCreacion = null;
        }
        public Usuario(int id,int idRolUsuario, string nombreCompleto, string correo, 
            string clave, bool estado, DateTime fechaCreacion)
        {
            this.Id = id;
            this.IdRolUsuario = idRolUsuario;
            this.NombreCompleto = nombreCompleto;
            this.Correo = correo;
            this.Clave = clave;
            Estado = estado;
            FechaCreacion = fechaCreacion;
        }
    }
}
