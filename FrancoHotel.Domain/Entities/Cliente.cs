using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Entities
{
    public sealed class Cliente : BaseEntity<int>, IAuditEntity
    {
        [Column("IdCliente")]
        [Key]
        public override int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public Cliente(string tipoDocumento, string documento, string nombreCompleto, string correo)
        {
            this.TipoDocumento = tipoDocumento;
            this.Documento = documento;
            this.NombreCompleto = nombreCompleto;
            this.Correo = correo;
            Estado = false;
            FechaCreacion = null;
        }
        public Cliente(int id,string tipoDocumento, string documento, string nombreCompleto, 
            string correo, bool estado, DateTime fechaCreacion)
        {
            this.Id = id;
            this.TipoDocumento = tipoDocumento;
            this.Documento = documento;
            this.NombreCompleto = nombreCompleto;
            this.Correo = correo;
            Estado = estado;
            FechaCreacion = fechaCreacion;
        }
    }
}
