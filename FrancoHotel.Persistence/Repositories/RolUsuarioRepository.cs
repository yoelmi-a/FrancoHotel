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
        private readonly ILogger<PisoRepository> _logger;
        private readonly IConfiguration _configuration;

        public RolUsuarioRepository(HotelContext context,
                              ILogger<PisoRepository> logger,
                              IConfiguration configuration) : base(context)
        {
            this._context = context;
            this._logger = logger;
            this._configuration = configuration;
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
                                             .Where(r => r.Borrado == false)
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

        public override async Task<RolUsuario?> GetEntityByIdAsync(int id)
        {
            if (RepoValidation.ValidarID(id))
            {
                return null;
            }
            return await _context.RolUsuario.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<RolUsuario> GetRolUsuarioByDescripcion(string descripcion)
        {
            return await _context.RolUsuario
                                 .AsNoTracking()
                                 .Where(r => r.Descripcion == descripcion)
                                 .FirstOrDefaultAsync()
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

        public override async Task<OperationResult> SaveEntityAsync(RolUsuario entity)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarRolUsuario(entity))
            {
                result.Message = this._configuration["ErrorRolUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.RolUsuario.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRolUsuarioRepository:SaveEntityAsync"]!;
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(RolUsuario entity)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarID(entity.Id) || !RepoValidation.ValidarRolUsuario(entity) || !RepoValidation.ValidarID(entity.UsuarioMod) || !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorRolUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.RolUsuario.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRolUsuarioRepository:UpdateEntityAsync"]!;
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<OperationResult> UpdateDescripcion(RolUsuario entity, string nuevaDescripcion)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarRolUsuario(entity) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorRolUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }

            try
            {
                entity.Descripcion = nuevaDescripcion;
                _context.RolUsuario.Update(entity);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorRolUsuarioRepository:UpdateEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<OperationResult> UpdateEstado(RolUsuario entity, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarRolUsuario(entity) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorRolUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                entity.EstadoYFecha.Estado = nuevoEstado;
                _context.RolUsuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorRolUsuarioRepository:UpdateEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override async Task<OperationResult> RemoveEntityAsync(RolUsuario entity)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarRolUsuario(entity) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!) ||
                !RepoValidation.ValidarID(entity.BorradoPorU) ||
                !RepoValidation.ValidarEntidad(entity.Borrado!))
            {
                result.Message = _configuration["ErrorRolUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.RolUsuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorRolUsuarioRepository:RemoveEntity"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}