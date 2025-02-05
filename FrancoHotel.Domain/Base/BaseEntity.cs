namespace FrancoHotel.Domain.Base
{
    public abstract class BaseEntity<Ttype>
    {
        public abstract Ttype Id { get; set; }
    }
}
