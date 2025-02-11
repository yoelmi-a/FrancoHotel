using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Base;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FrancoHotel.Persistence.Repositories
{
    public class RolUsuarioRepository : BaseRepository<RolUsuario, int>, IRolUsuarioRepository
    {
        private readonly HotelContext _context;
        private readonly ILogger<RolUsuarioRepository> _logger;
        private readonly IConfiguration _configuration;

        public RolUsuarioRepository(HotelContext context,
                                    ILogger<RolUsuarioRepository> logger,
                                    IConfiguration configuration) : base(context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<RolUsuario> GetRolUsuarioByDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía o ser nula.", nameof(descripcion));
            }

            return await _context.RolUsuarios
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(r => r.Descripcion == descripcion);
        }

        public async Task<List<RolUsuario>> GetRolesUsuarioByEstado(bool estado)
        {
            return await _context.RolUsuarios
                                  .AsNoTracking()
                                  .Where(r => r.EstadoYFecha.Estado == estado)
                                  .ToListAsync();
        }

        public async Task<OperationResult> UpdateDescripcion(int idRolUsuario, string nuevaDescripcion)
        {
            OperationResult result = new OperationResult();
            if (idRolUsuario <= 0)
            {
                result.Success = false;
                result.Message = "El ID del rol de usuario debe ser mayor que cero.";
                return result;
            }

            if (string.IsNullOrWhiteSpace(nuevaDescripcion))
            {
                result.Success = false;
                result.Message = "La nueva descripción no puede estar vacía o ser nula.";
                return result;
            }

            try
            {
                var rolUsuario = await _context.RolUsuarios.FindAsync(idRolUsuario);
                if (rolUsuario == null)
                {
                    result.Success = false;
                    result.Message = "Rol de usuario no encontrado.";
                    return result;
                }

                rolUsuario.Descripcion = nuevaDescripcion;
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "Descripción actualizada correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la descripción del rol de usuario.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<OperationResult> UpdateEstado(int idRolUsuario, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();
            if (idRolUsuario <= 0)
            {
                result.Success = false;
                result.Message = "El ID del rol de usuario debe ser mayor que cero.";
                return result;
            }

            try
            {
                var rolUsuario = await _context.RolUsuarios.FindAsync(idRolUsuario);
                if (rolUsuario == null)
                {
                    result.Success = false;
                    result.Message = "Rol de usuario no encontrado.";
                    return result;
                }

                rolUsuario.EstadoYFecha.Estado = nuevoEstado;
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "Estado actualizado correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando el estado del rol de usuario.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}