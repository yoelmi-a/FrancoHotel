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
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<RolUsuario> GetRolUsuarioByDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía o ser nula.", nameof(descripcion));
            }

            return await _context.RolUsuario
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(r => r.Descripcion == descripcion)
                                 .ConfigureAwait(false);
        }

        public async Task<List<RolUsuario>> GetRolesUsuarioByEstado(bool estado)
        {
            return await _context.RolUsuario
                                  .AsNoTracking()
                                  .Where(r => r.EstadoYFecha.Estado == estado)
                                  .ToListAsync()
                                  .ConfigureAwait(false);
        }

        public override async Task<bool> Exists(Expression<Func<RolUsuario, bool>> filter)
        {
            return await _context.RolUsuario.AnyAsync(filter).ConfigureAwait(false);
        }

        public override async Task<List<RolUsuario>> GetAllAsync()
        {
            return await _context.RolUsuario
                                 .AsNoTracking()
                                 .ToListAsync()
                                 .ConfigureAwait(false);
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<RolUsuario, bool>> filter)
        {
            var rolesUsuario = await _context.RolUsuario
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
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            }

            return await _context.RolUsuario
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(r => r.Id == id)
                                 .ConfigureAwait(false);
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

                if (nuevaDescripcion.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La descripción no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                var rolUsuario = await _context.RolUsuario.FindAsync(idRolUsuario);
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

                var rolUsuario = await _context.RolUsuario.FindAsync(idRolUsuario);
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

                if (string.IsNullOrWhiteSpace(entity.Descripcion) || entity.Descripcion.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El campo Descripción no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                _context.RolUsuario.Add(entity);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Rol de usuario guardado correctamente.";
                _logger.LogInformation("Rol de usuario guardado con ID: {IdRolUsuario}", entity.Id);
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

                if (string.IsNullOrWhiteSpace(entity.Descripcion) || entity.Descripcion.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La descripción no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                var existingEntity = await _context.RolUsuario.FindAsync(entity.Id);
                if (existingEntity == null)
                {
                    result.Success = false;
                    result.Message = "El rol de usuario no existe en la base de datos.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                existingEntity.Descripcion = entity.Descripcion;
                existingEntity.EstadoYFecha.Estado = entity.EstadoYFecha.Estado;

                _context.RolUsuario.Update(existingEntity);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Rol de usuario actualizado correctamente.";
                _logger.LogInformation("Rol de usuario actualizado con ID: {IdRolUsuario}", entity.Id);
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