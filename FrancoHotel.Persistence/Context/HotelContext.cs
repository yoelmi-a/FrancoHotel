using FrancoHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrancoHotel.Persistence.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<EstadoHabitacion> EstadoHabitaciones { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Piso> Pisos { get; set; }
        public DbSet<Recepcion> Recepciones { get; set; }
        public DbSet<RolUsuario> RolUsuario { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Tarifas> Tarifas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
