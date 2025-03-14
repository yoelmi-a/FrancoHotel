using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FrancoHotel.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolUsuarioRepository _rolUsuarioRepository;
        private readonly IUsuarioMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IRolUsuarioRepository rolUsuarioRepository,
            IUsuarioMapper mapper,
            IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _rolUsuarioRepository = rolUsuarioRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            var usuarios = await _usuarioRepository.GetAllAsync();
            result.Data = _mapper.DtoList(usuarios);
            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new OperationResult();
            var usuario = await _usuarioRepository.GetEntityByIdAsync(id);

            if (usuario == null || (usuario.Borrado ?? false))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:UsuarioNoEncontrado"];
                return result;
            }

            result.Data = _mapper.EntityToDto(usuario);
            return result;
        }

        public async Task<OperationResult> GetUsuarioByIdRolUsuario(int idRolUsuario)
        {
            OperationResult result = new OperationResult();
            bool rolExiste = await _rolUsuarioRepository.Exists(r => r.Id == idRolUsuario);

            if (!rolExiste)
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:RolNoExiste"];
                return result;
            }

            var usuario = await _usuarioRepository.GetUsuarioByIdRolUsuario(idRolUsuario);
            result.Data = _mapper.EntityToDto(usuario);
            return result;
        }

        public async Task<List<OperationResult>> GetUsuariosByEstado(bool estado)
        {
            var usuarios = await _usuarioRepository.GetUsuariosByEstado(estado);
            return usuarios.Select(u => new OperationResult { Data = _mapper.EntityToDto(u) }).ToList();
        }

        public async Task<OperationResult> Save(SaveUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(dto.Correo) || !dto.Correo.Contains("@"))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:CorreoFormatoInvalido"];
                return result;
            }

            if (!await _rolUsuarioRepository.Exists(r => r.Id == dto.IdRolUsuario))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:RolNoExiste"];
                return result;
            }

            if (await _usuarioRepository.Exists(u => u.Correo == dto.Correo))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:CorreoDuplicado"];
                return result;
            }

            var nuevoUsuario = _mapper.SaveDtoToEntity(dto);
            result = await _usuarioRepository.SaveEntityAsync(nuevoUsuario);
            return result;
        }

        public async Task<OperationResult> Update(UpdateUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();
            if (!dto.IdUsuario.HasValue)
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:IdObligatorio"];
                return result;
            }

            var usuarioExistente = await _usuarioRepository.GetEntityByIdAsync(dto.IdUsuario.Value);
            if (usuarioExistente == null || (usuarioExistente.Borrado ?? false))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:UsuarioNoEncontrado"];
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.Correo) || !dto.Correo.Contains("@"))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:CorreoFormatoInvalido"];
                return result;
            }

            if (await _usuarioRepository.Exists(u => u.Correo == dto.Correo && u.Id != dto.IdUsuario))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:CorreoDuplicado"];
                return result;
            }

            if (!await _rolUsuarioRepository.Exists(r => r.Id == dto.IdRolUsuario))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:RolNoExiste"];
                return result;
            }

            var usuarioActualizado = _mapper.UpdateDtoToEntity(dto, usuarioExistente);
            result = await _usuarioRepository.UpdateEntityAsync(usuarioActualizado);
            return result;
        }

        public async Task<OperationResult> Remove(RemoveUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();
            var usuario = await _usuarioRepository.GetEntityByIdAsync(dto.IdUsuario);

            if (usuario == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:UsuarioNoEncontrado"];
                return result;
            }

            usuario.Borrado = true;
            result = await _usuarioRepository.UpdateEntityAsync(usuario);
            return result;
        }

        public async Task<OperationResult> UpdateClave(Usuario usuario, string nuevaClave)
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(nuevaClave))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuario:NuevaClaveVacia"];
                return result;
            }

            usuario.Clave = nuevaClave;
            result = await _usuarioRepository.UpdateEntityAsync(usuario);
            return result;
        }
        public async Task<OperationResult> UpdateEstado(Usuario entity, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();

            Usuario usuario = await _usuarioRepository.GetEntityByIdAsync(entity.Id);
            if (usuario == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioService:UsuarioNoExiste"];
                return result;
            }

            usuario.EstadoYFecha.Estado = nuevoEstado;
            result = await _usuarioRepository.UpdateEntityAsync(usuario);
            return result;
        }
    }
}
