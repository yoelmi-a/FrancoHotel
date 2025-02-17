using System.Linq.Expressions;
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

        public override async Task<bool> Exists(Expression<Func<RolUsuario, bool>> filter)
        {
            return await _context.RolUsuarios.AnyAsync(filter).ConfigureAwait(false);
        }

        public override async Task<List<RolUsuario>> GetAllAsync()
        {
            return await _context.RolUsuarios
                                 .AsNoTracking()
                                 .ToListAsync()
                                 .ConfigureAwait(false);
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<RolUsuario, bool>> filter)
        {
            var rolesUsuario = await _context.RolUsuarios
                                             .AsNoTracking()
                                             .Where(filter)
                                             .ToListAsync()
                                             .ConfigureAwait(false);

            return new OperationResult
            {
                Success = true,
                Data = rolesUsuario
            };
        }

        public override async Task<RolUsuario> GetEntityByIdAsync(int id)
        {
            return await _context.RolUsuarios
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<OperationResult> UpdateDescripcion(int idRolUsuario, string nuevaDescripcion)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (idRolUsuario <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del rol de usuario debe ser mayor que cero.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(nuevaDescripcion))
                {
                    result.Success = false;
                    result.Message = "La nueva descripción no puede estar vacía o ser nula.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                var rolUsuario = await _context.RolUsuarios.FindAsync(idRolUsuario);
                if (rolUsuario == null)
                {
                    result.Success = false;
                    result.Message = "Rol de usuario no encontrado.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                rolUsuario.Descripcion = nuevaDescripcion;
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Descripción actualizada correctamente.";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la descripción del rol de usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<OperationResult> UpdateEstado(int idRolUsuario, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (idRolUsuario <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del rol de usuario debe ser mayor que cero.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                var rolUsuario = await _context.RolUsuarios.FindAsync(idRolUsuario);
                if (rolUsuario == null)
                {
                    result.Success = false;
                    result.Message = "Rol de usuario no encontrado.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                rolUsuario.EstadoYFecha.Estado = nuevoEstado;
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Estado actualizado correctamente.";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando el estado del rol de usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public override async Task<OperationResult> SaveEntityAsync(RolUsuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "El rol de usuario no puede ser nulo.");
                }

                await _context.RolUsuarios.AddAsync(entity).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                result.Success = true;
                result.Message = "Rol de usuario guardado correctamente.";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error al guardar el rol de usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(RolUsuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "El rol de usuario no puede ser nulo.");
                }

                var rolUsuarioExistente = await GetEntityByIdAsync(entity.Id);

                if (rolUsuarioExistente == null)
                {
                    result.Success = false;
                    result.Message = "El rol de usuario no existe en la base de datos.";
                    return result;
                }

                _context.Entry(rolUsuarioExistente).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                result.Success = true;
                result.Message = "Rol de usuario actualizado correctamente .";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error al actualizar el rol de usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}