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

            return await _context.Usuarios
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

            return await _context.Usuarios
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.IdRolUsuario == idRolUsuario);
        }

        public async Task<List<Usuario>> GetUsuariosByEstado(bool estado)
        {
            return await _context.Usuarios
                                  .AsNoTracking()
                                  .Where(u => u.EstadoYFecha.Estado == estado)
                                  .ToListAsync();
        }

        public override async Task<bool> Exists(Expression<Func<Usuario, bool>> filter)
        {
            return await _context.Usuarios.AnyAsync(filter).ConfigureAwait(false);
        }

        public override async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                                 .AsNoTracking()
                                 .ToListAsync()
                                 .ConfigureAwait(false);
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Usuario, bool>> filter)
        {
            var usuarios = await _context.Usuarios
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

            return await _context.Usuarios
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<OperationResult> UpdateClave(int idUsuario, string nuevaClave)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (idUsuario <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del usuario debe ser mayor que cero.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(nuevaClave))
                {
                    result.Success = false;
                    result.Message = "La nueva clave no puede estar vacía o ser nula.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (nuevaClave.Length < 8)
                {
                    result.Success = false;
                    result.Message = "La clave debe tener al menos 8 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                var usuario = await _context.Usuarios.FindAsync(idUsuario);
                if (usuario == null)
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                usuario.Clave = nuevaClave;
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Clave actualizada correctamente.";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la clave del usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<OperationResult> UpdateEstado(int idUsuario, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (idUsuario <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del usuario debe ser mayor que cero.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                var usuario = await _context.Usuarios.FindAsync(idUsuario);
                if (usuario == null)
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                usuario.EstadoYFecha.Estado = nuevoEstado;
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Estado actualizado correctamente.";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando el estado del usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public async Task<OperationResult> GetUsuariosByEstadoYFechaCreacion(bool estado, DateTime fechaCreacion)
        {
            OperationResult result = new OperationResult();
            try
            {
                var query = await (from usuario in _context.Usuarios
                                   where usuario.EstadoYFecha.Estado.GetValueOrDefault() == estado &&
                                         usuario.EstadoYFecha.FechaCreacion.GetValueOrDefault() >= fechaCreacion
                                   select new UsuarioModel()
                                   {
                                       IdUsuario = usuario.Id,
                                       NombreCompleto = usuario.NombreCompleto ?? string.Empty,
                                       Clave = usuario.Clave ?? string.Empty,
                                       IdRolUsuario = usuario.IdRolUsuario ?? 0,
                                       Estado = usuario.EstadoYFecha.Estado.GetValueOrDefault(),
                                       FechaCreacion = usuario.EstadoYFecha.FechaCreacion.GetValueOrDefault()
                                   }).ToListAsync();

                result.Data = query;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioRepository:GetUsuariosByEstadoYFechaCreacion"]
                    ?? "Ocurrió un error al obtener los usuarios.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        public override async Task<OperationResult> SaveEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (entity.Id <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del usuario debe ser mayor que cero.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (entity.NombreCompleto != null && entity.NombreCompleto.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El nombre completo no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (entity.Correo != null && entity.Correo.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El correo no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (entity.Clave != null && entity.Clave.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La clave no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                await _context.Usuarios.AddAsync(entity).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                result.Success = true;
                result.Message = "Usuario guardado correctamente.";
                _logger.LogInformation(result.Message);
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
                if (entity.Id <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del usuario debe ser mayor que cero.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (entity.NombreCompleto != null && entity.NombreCompleto.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El nombre completo no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (entity.Correo != null && entity.Correo.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El correo no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (entity.Clave != null && entity.Clave.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La clave no puede exceder los 50 caracteres.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                var usuarioExistente = await GetEntityByIdAsync(entity.Id);

                if (usuarioExistente == null)
                {
                    result.Success = false;
                    result.Message = "El usuario no existe en la base de datos.";
                    return result;
                }

                _context.Entry(usuarioExistente).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                result.Success = true;
                result.Message = "Usuario actualizado correctamente.";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error al actualizar el usuario.";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}