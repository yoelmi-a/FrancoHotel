using System.Linq.Expressions;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Models.Models;
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
        private static bool nuevoEstado;
        private static string? nuevaClave;

        public UsuarioRepository(HotelContext context,
                                 ILogger<UsuarioRepository> logger,
                                 IConfiguration configuration) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<List<Usuario>> GetUsuarioByClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave) || clave.Contains(" "))
            {
                _logger.LogWarning("El documento proporcionado es inválido.");
                return new List<Usuario>();
            }

            return await _context.Usuario
                                 .AsNoTracking()
                                 .Where(c => c.Clave != null && c.Clave == clave)
                                 .ToListAsync()
                                 .ConfigureAwait(false);
        }

        public async Task<Usuario> GetUsuarioByIdRolUsuario(int idRolUsuario)
        {
            if (idRolUsuario == null || idRolUsuario <= 0)
            {
                _logger.LogWarning("El ID proporcionado no es válido: {Id}", idRolUsuario);
                return null;
            }

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

        public override async Task<Usuario> GetEntityByIdAsync(int id)
        {
            if (id == null || id <= 0)
            {
                _logger.LogWarning("El ID proporcionado no es válido: {Id}", id);
                return null;
            }

            return await _context.Usuario
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<OperationResult> UpdateClave(Usuario entity, string nuevaClave)
        {
            OperationResult result = new OperationResult();
            try
            {
                ValidationOfUsuario(entity, result);
                if (!result.Success)
                {
                    result.Message = this._configuration["ErrorUsuarioRepository:InvalidData"];
                    return result;
                }

                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:UpdateClave"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> UpdateEstado(Usuario entity, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();
            try
            {
                ValidationOfUsuario(entity, result);
                if (!result.Success)
                {
                    result.Message = this._configuration["ErrorUsuarioRepository:InvalidData"];
                    return result;
                }

                entity.EstadoYFecha.Estado = nuevoEstado;
                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:UpdateEstado"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public override async Task<OperationResult> SaveEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                ValidationOfUsuario(entity, result);
                if (!result.Success)
                {
                    result.Message = this._configuration["ErrorUsuarioRepository:InvalidData"];
                    return result;
                }

                _context.Usuario.Add(entity);
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


        public override async Task<OperationResult> UpdateEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                ValidationOfUsuario(entity, result);
                if (!result.Success)
                {
                    result.Message = this._configuration["ErrorUsuarioRepository:InvalidData"];
                    return result;
                }

                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
        private static OperationResult ValidationOfUsuario(Usuario entity, OperationResult result)
        {
            if (entity == null)
            {
                result.Success = false;
                return result;
            }
            if (string.IsNullOrWhiteSpace(entity.Correo) || entity.Correo.Length > 50)
            {
                result.Success = false;
                return result;
            }
            if (string.IsNullOrWhiteSpace(entity.Clave) || entity.Clave.Length > 50)
            {
                result.Success = false;
                return result;
            }
            if (entity.EstadoYFecha.Estado == null)
            {
                result.Success = false;
                return result;
            }
            if (entity.EstadoYFecha.Estado == nuevoEstado)
            {
                result.Success = false;
                return result;
            }
            if (string.IsNullOrWhiteSpace(nuevaClave))
            {
                result.Success = false;
                return result;
            }
            if (nuevaClave.Length < 8 || nuevaClave.Length > 50)
            {
                result.Success = false;
                return result;
            }

            return result;
        }
    }
}