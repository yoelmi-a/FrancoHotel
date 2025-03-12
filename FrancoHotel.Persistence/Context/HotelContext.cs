using FrancoHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrancoHotel.Persistence.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<EstadoHabitacion> EstadoHabitacion { get; set; }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Piso> Piso { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Recepcion> Recepcion { get; set; }
        public DbSet<RolUsuario> RolUsuario { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Tarifas> Tarifas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<CategoriaServicios> CategoriaServicios { get; set; }
        public DbSet<CombinacionServiciosCategoria> CombinacionServiciosCategorias { get; set; }
        public DbSet<ServiciosExtra> ServiciosExtra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiciosExtra>()
                .HasKey(se => new { se.IdServicio, se.IdRecepcion });
            modelBuilder.Entity<Recepcion>()
                .Property(r => r.Estado)
                .HasConversion<byte>();
        }
    }
}
