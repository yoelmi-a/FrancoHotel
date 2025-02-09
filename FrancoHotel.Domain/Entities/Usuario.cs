
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Usuario : Person<int>, IAuditEntity
    {
        [Key]
        [Column("IdUsuario")]
        public override int Id { get; set; }

        public int? IdRolUsuario { get; set; }
        public string? Clave { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public Usuario() { }

        public Usuario(int? idRolUsuario = null, string? nombreCompleto = null,
            string? correo = null, string? clave = null, bool? estado = null,
            DateTime? fechaCreacion = null)
        {
            IdRolUsuario = idRolUsuario;
            NombreCompleto = nombreCompleto;
            Correo = correo;
            Clave = clave;
            Estado = estado;
            FechaCreacion = fechaCreacion;
        }

        public Usuario(int id, int? idRolUsuario = null, string? nombreCompleto = null,
            string? correo = null, string? clave = null, bool? estado = null,
            DateTime? fechaCreacion = null) : this(idRolUsuario, nombreCompleto, 
                correo, clave, estado, fechaCreacion)
        {
            Id = id;
        }
    }
}