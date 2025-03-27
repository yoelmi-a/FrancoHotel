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
    public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository
    {
        private readonly HotelContext _context;
        private readonly ILogger<UsuarioRepository> _logger;
        private readonly IConfiguration _configuration;

        public UsuarioRepository(HotelContext context,
                              ILogger<UsuarioRepository> logger,
                              IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public override async Task<bool> Exists(Expression<Func<Usuario, bool>> filter)
        {
            return await _context.Usuario.AnyAsync(filter).ConfigureAwait(false);
        }

        public override async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuario
                                 .AsNoTracking()
                                 .ToListAsync()
                                 .ConfigureAwait(false);
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Usuario, bool>> filter)
        {
            var usuarios = await _context.Usuario
                                         .Where(u => u.Borrado == false)
                                         .AsNoTracking()
                                         .Where(filter)
                                         .ToListAsync()
                                         .ConfigureAwait(false);

            return new OperationResult
            {
                Success = true,
                Data = usuarios
            };
        }

        public override async Task<Usuario?> GetEntityByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<Usuario?> GetUsuarioByIdRolUsuario(int idRolUsuario)
        {
            return await _context.Usuario
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.IdRolUsuario == idRolUsuario);
        }

        public async Task<List<Usuario>> GetUsuariosByEstado(bool estado)
        {
            return await _context.Usuario
                                  .AsNoTracking()
                                  .Where(u => u.EstadoYFecha.Estado == estado)
                                  .ToListAsync();
        }

        public override async Task<OperationResult> SaveEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarUsuario(entity))
            {
                result.Message = this._configuration["ErrorUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Usuario.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:SaveEntityAsync"]!;
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarUsuario(entity) || !RepoValidation.ValidarID(entity.Id) || !RepoValidation.ValidarID(entity.UsuarioMod) || !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:UpdateEntityAsync"]!;
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<OperationResult> UpdateClave(Usuario entity, string nuevaClave)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarUsuario(entity) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }

            try
            {
                entity.Clave = nuevaClave;
                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorUsuarioRepository:UpdateEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<OperationResult> UpdateEstado(Usuario entity, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarUsuario(entity) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                entity.EstadoYFecha.Estado = nuevoEstado;
                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorUsuarioRepository:UpdateEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override async Task<OperationResult> RemoveEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarUsuario(entity) ||
                !RepoValidation.ValidarID(entity.Id) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!) ||
                !RepoValidation.ValidarID(entity.BorradoPorU) ||
                !RepoValidation.ValidarEntidad(entity.Borrado!))
            {
                result.Message = _configuration["ErrorUsuarioRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorUsuarioRepository:RemoveEntity"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}