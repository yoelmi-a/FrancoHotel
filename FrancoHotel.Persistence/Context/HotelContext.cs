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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoHabitacion> EstadoHabitacion { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Piso> Piso { get; set; }
        public DbSet<Recepcion> Recepciones { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Tarifas> Tarifas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
