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

        public UsuarioRepository(HotelContext context,
                                 ILogger<UsuarioRepository> logger,
                                 IConfiguration configuration) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Usuario> GetUsuarioByClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
            {
                _logger.LogWarning("La clave proporcionada es nula o vacía.");
                return null;
            }

            return await _context.Usuario
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.Clave == clave);
        }

        public async Task<Usuario> GetUsuarioByIdRolUsuario(int idRolUsuario)
        {
            if (idRolUsuario <= 0)
            {
                _logger.LogWarning("El ID del rol de usuario debe ser mayor que cero.");
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
            if (id <= 0)
            {
                _logger.LogWarning("El ID del usuario debe ser mayor que cero.");
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
                if (string.IsNullOrWhiteSpace(nuevaClave))
                {
                    result.Success = false;
                    result.Message = "La nueva clave no puede estar vacía o ser nula.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (nuevaClave.Length < 8 || nuevaClave.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La clave debe tener entre 8 y 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Clave actualizada correctamente.";
                _logger.LogInformation("Clave actualizada para el usuario con ID: {IdUsuario}", entity);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la clave del usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<OperationResult> UpdateEstado(Usuario entity, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "El usuario no puede ser nulo.");
                }

                if (entity.EstadoYFecha.Estado == nuevoEstado)
                {
                    result.Success = false;
                    result.Message = "El nuevo estado es el mismo que el actual.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                entity.EstadoYFecha.Estado = nuevoEstado;
                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Estado actualizado correctamente.";
                _logger.LogInformation("Estado actualizado para el cliente con ID: {IdCliente}", entity.Id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando el estado del usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public override async Task<OperationResult> SaveEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "El usuario no puede ser nulo.");
                }

                if (string.IsNullOrWhiteSpace(entity.Correo) || entity.Correo.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El campo Correo no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(entity.Clave) || entity.Clave.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El campo Clave no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (entity.EstadoYFecha.Estado == null)
                {
                    result.Success = false;
                    result.Message = "El campo Estado no puede ser nulo.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                _context.Usuario.Add(entity);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Usuario guardado correctamente.";
                _logger.LogInformation("Usuario guardado con ID: {IdUsuario}", entity.Id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error al guardar el usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }


        public override async Task<OperationResult> UpdateEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "El usuario no puede ser nulo.");
                }

                if (string.IsNullOrWhiteSpace(entity.Correo) || entity.Correo.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El campo Correo no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(entity.Clave) || entity.Clave.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El campo Clave no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (entity.EstadoYFecha.Estado == null)
                {
                    result.Success = false;
                    result.Message = "El campo Estado no puede ser nulo.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Usuario actualizado correctamente.";
                _logger.LogInformation("Usuario actualizado con ID: {IdUsuario}", entity.Id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error al actualizar el usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public override async Task<OperationResult> RemoveEntityAsync(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                await _context.Usuario.Where(e => e.Id == id).ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Borrado, true));
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["ErrorUsuarioRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}