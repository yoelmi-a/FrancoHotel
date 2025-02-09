namespace FrancoHotel.Domain.Base
{
    public abstract class Person<Ttype> : BaseEntity<Ttype>
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
    }
}
