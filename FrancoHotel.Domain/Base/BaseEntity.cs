namespace FrancoHotel.Domain.Base
{
    public abstract class BaseEntity<Ttype>
    {
        public abstract Ttype Id { get; set; }

        public int? CreadorPorU { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioMod { get; set; }
        public int? BorradoPorU { get; set; }
        public bool? Borrado { get; set; }
    }
}
