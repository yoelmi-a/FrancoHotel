using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrancoHotel.Domain.Base;

public sealed class RolUsuario : BaseEntity<int>, IAuditEntity
{
    [Key]
    [Column("IdRolUsuario")]
    public override int Id { get; set; }

    public string? Descripcion { get; set; }
    public bool? Estado { get; set; }
    public DateTime? FechaCreacion { get; set; }

    public RolUsuario() { }

    public RolUsuario(string? descripcion = null)
    {
        Descripcion = descripcion;
        Estado = null;
        FechaCreacion = null;
    }

    public RolUsuario(int id, string? descripcion = null, bool? estado = null,
        DateTime? fechaCreacion = null)
    {
        Id = id;
        Descripcion = descripcion;
        Estado = estado;
        FechaCreacion = fechaCreacion;
    }
}