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
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<Usuario> GetUsuarioByClave(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
            {
                throw new ArgumentException("La clave no puede estar vacía o ser nula.", nameof(clave));
            }

            return await _context.Usuarios
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.Clave == clave);
        }

        public async Task<Usuario> GetUsuarioByIdRolUsuario(int idRolUsuario)
        {
            if (idRolUsuario <= 0)
            {
                throw new ArgumentException("El ID del rol de usuario debe ser mayor que cero.", nameof(idRolUsuario));
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

        public async Task<OperationResult> UpdateClave(int idUsuario, string nuevaClave)
        {
            OperationResult result = new OperationResult();
            if (idUsuario <= 0)
            {
                result.Success = false;
                result.Message = "El ID del usuario debe ser mayor que cero.";
                return result;
            }

            if (string.IsNullOrWhiteSpace(nuevaClave))
            {
                result.Success = false;
                result.Message = "La nueva clave no puede estar vacía o ser nula.";
                return result;
            }

            try
            {
                var usuario = await _context.Usuarios.FindAsync(idUsuario);
                if (usuario == null)
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado.";
                    return result;
                }

                usuario.Clave = nuevaClave;
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "Clave actualizada correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la clave del usuario.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<OperationResult> UpdateEstado(int idUsuario, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();
            if (idUsuario <= 0)
            {
                result.Success = false;
                result.Message = "El ID del usuario debe ser mayor que cero.";
                return result;
            }

            try
            {
                var usuario = await _context.Usuarios.FindAsync(idUsuario);
                if (usuario == null)
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado.";
                    return result;
                }

                usuario.EstadoYFecha.Estado = nuevoEstado;
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "Estado actualizado correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando el estado del usuario.";
                _logger.LogError(result.Message, ex.ToString());
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
                result.Message = _configuration["ErrorUsuarioRepository:GetUsuariosByEstadoYFechaCreacion"] ?? "Ocurrió un error al obtener los usuarios.";
                result.Success = false;
                _logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}