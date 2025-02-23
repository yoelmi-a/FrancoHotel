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
        private static bool nuevoEstado;
        private static string? nuevaDescripcion;

        public RolUsuarioRepository(HotelContext context,
                                    ILogger<RolUsuarioRepository> logger,
                                    IConfiguration configuration) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<List<RolUsuario>> GetRolUsuarioByDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion) || descripcion.Contains(" "))
            {
                _logger.LogWarning("El documento proporcionado es inválido.");
                return new List<RolUsuario>();
            }

            return await _context.RolUsuario
                                 .AsNoTracking()
                                 .Where(r => r.Descripcion != null && r.Descripcion == descripcion)
                                 .ToListAsync()
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
            if (id == null || id <= 0)
            {
                _logger.LogWarning("El ID proporcionado no es válido: {Id}", id);
                return null;
            }

            return await _context.RolUsuario
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(r => r.Id == id)
                                 .ConfigureAwait(false);
        }

        public async Task<OperationResult> UpdateDescripcion(RolUsuario entity, string nuevaDescripcion)
        {
            OperationResult result = new OperationResult();
            try
            {
                ValidationOfRolUsuario(entity, result);
                if (!result.Success)
                {
                    result.Message = this._configuration["ErrorRolUsuarioRepository:InvalidData"];
                    return result;
                }

                entity.Descripcion = nuevaDescripcion;
                _context.RolUsuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRolUsuarioRepository:UpdateClave"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> UpdateEstado(RolUsuario entity, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();
            try
            {
                ValidationOfRolUsuario(entity, result);
                if (!result.Success)
                {
                    result.Message = this._configuration["ErrorRolUsuarioRepository:InvalidData"];
                    return result;
                }

                entity.EstadoYFecha.Estado = nuevoEstado;
                _context.RolUsuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRolUsuarioRepository:UpdateEstado"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override async Task<OperationResult> SaveEntityAsync(RolUsuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                ValidationOfRolUsuario(entity, result);
                if (!result.Success)
                {
                    result.Message = this._configuration["ErrorRolUsuarioRepository:InvalidData"];
                    return result;
                }

                _context.RolUsuario.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(RolUsuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                ValidationOfRolUsuario(entity, result);
                if (!result.Success)
                {
                    result.Message = this._configuration["ErrorRolUsuarioRepository:InvalidData"];
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
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRolUsuarioRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        private static OperationResult ValidationOfRolUsuario(RolUsuario entity, OperationResult result)
        {
            if (entity == null)
            {
                result.Success = false;
                return result;
            }
            if (string.IsNullOrWhiteSpace(entity.Descripcion) || entity.Descripcion.Length > 50)
            {
                result.Success = false;
                return result;
            }
            if (entity.EstadoYFecha.Estado == nuevoEstado)
            {
                result.Success = false;
                return result;
            }
            if (string.IsNullOrWhiteSpace(nuevaDescripcion))
            {
                result.Success = false;
                return result;
            }
            if (nuevaDescripcion.Length > 50)
            {
                result.Success = false;
                return result;
            }

            return result;
        }
    }
}