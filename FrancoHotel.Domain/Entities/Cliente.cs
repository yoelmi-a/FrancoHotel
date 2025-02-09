using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Cliente : Person<int>, IAuditEntity
    {
        [Key]
        [Column("IdCliente")]
        public override int Id { get; set; }

        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public Cliente() { }

        public Cliente(string? tipoDocumento = null, string? documento = null,
            string? nombreCompleto = null, string? correo = null)
        {
            TipoDocumento = tipoDocumento;
            Documento = documento;
            NombreCompleto = nombreCompleto;
            Correo = correo;
            Estado = null;
            FechaCreacion = null;
        }

        public Cliente(int id, string? tipoDocumento = null, string? documento = null,
            string? nombreCompleto = null, string? correo = null, bool? estado = null,
            DateTime? fechaCreacion = null)
        {
            Id = id;
            TipoDocumento = tipoDocumento;
            Documento = documento;
            NombreCompleto = nombreCompleto;
            Correo = correo;
            Estado = estado;
            FechaCreacion = fechaCreacion;
        }
    }
}