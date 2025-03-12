using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;

namespace FrancoHotel.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolUsuarioRepository _rolUsuarioRepository;
        private readonly IUsuarioMapper _mapper;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IRolUsuarioRepository rolUsuarioRepository,
            IUsuarioMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _rolUsuarioRepository = rolUsuarioRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> GetAll()
        {
            var result = new OperationResult();
            var usuarios = await _usuarioRepository.GetAllAsync();
            result.Data = _mapper.DtoList(usuarios);
            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            var result = new OperationResult();
            var usuario = await _usuarioRepository.GetEntityByIdAsync(id);

            if (usuario == null || (usuario.Borrado ?? false))
            {
                result.Success = false;
                result.Message = "Usuario no encontrado";
                return result;
            }

            result.Data = _mapper.EntityToDto(usuario);
            return result;
        }

        public async Task<OperationResult> GetUsuarioByIdRolUsuario(int idRolUsuario)
        {
            var result = new OperationResult();
            var rolExists = await _rolUsuarioRepository.Exists(r => r.Id == idRolUsuario);

            if (!rolExists)
            {
                result.Success = false;
                result.Message = "El rol especificado no existe";
                return result;
            }

            var usuarios = await _usuarioRepository.GetUsuarioByIdRolUsuario(idRolUsuario);
            result.Data = _mapper.EntityToDto(usuarios);
            return result;
        }

        public async Task<List<OperationResult>> GetUsuariosByEstado(bool estado)
        {
            var usuarios = await _usuarioRepository.GetUsuariosByEstado(estado);
            return usuarios.Select(u => new OperationResult
            {
                Data = _mapper.EntityToDto(u)
            }).ToList();
        }

        public async Task<OperationResult> Remove(RemoveUsuarioDtos dto)
        {
            var result = new OperationResult();
            var usuario = await _usuarioRepository.GetEntityByIdAsync(dto.IdUsuario);

            if (usuario == null)
            {
                result.Success = false;
                result.Message = "Usuario no encontrado";
                return result;
            }

            usuario.Borrado = true;
            result = await _usuarioRepository.UpdateEntityAsync(usuario);
            result.Message = "Usuario eliminado correctamente";
            return result;
        }

        public async Task<OperationResult> Save(SaveUsuarioDtos dto)
        {
            var result = new OperationResult();

            if (!dto.Correo.Contains("@"))
            {
                result.Success = false;
                result.Message = "Formato de correo inválido";
                return result;
            }

            if (!await _rolUsuarioRepository.Exists(r => r.Id == dto.IdRolUsuario))
            {
                result.Success = false;
                result.Message = "El rol especificado no existe";
                return result;
            }

            if (await _usuarioRepository.Exists(u => u.Correo == dto.Correo))
            {
                result.Success = false;
                result.Message = "El correo ya está registrado";
                return result;
            }

            var nuevoUsuario = _mapper.SaveDtoToEntity(dto);
            result = await _usuarioRepository.SaveEntityAsync(nuevoUsuario);
            result.Message = "Usuario creado correctamente";
            return result;
        }

        public async Task<OperationResult> Update(UpdateUsuarioDtos dto)
        {
            var result = new OperationResult();
            var usuarioExistente = await _usuarioRepository.GetEntityByIdAsync(dto.IdUsuario.Value);

            if (usuarioExistente == null)
            {
                result.Success = false;
                result.Message = "Usuario no encontrado";
                return result;
            }

            if (!dto.Correo.Contains("@"))
            {
                result.Success = false;
                result.Message = "Formato de correo inválido";
                return result;
            }

            if (await _usuarioRepository.Exists(u =>
                u.Correo == dto.Correo &&
                u.Id != dto.IdUsuario))
            {
                result.Success = false;
                result.Message = "El correo ya está registrado";
                return result;
            }

            if (!await _rolUsuarioRepository.Exists(r => r.Id == dto.IdRolUsuario))
            {
                result.Success = false;
                result.Message = "El rol especificado no existe";
                return result;
            }

            var usuarioActualizado = _mapper.UpdateDtoToEntity(dto, usuarioExistente);
            result = await _usuarioRepository.UpdateEntityAsync(usuarioActualizado);
            result.Message = "Usuario actualizado correctamente";
            return result;
        }

        public async Task<OperationResult> UpdateClave(Usuario usuario, string nuevaClave)
        {
            var result = new OperationResult();
            usuario.Clave = nuevaClave;
            result = await _usuarioRepository.UpdateEntityAsync(usuario);
            result.Message = "Contraseña actualizada correctamente";
            return result;
        }

        public async Task<OperationResult> UpdateEstado(Usuario usuario, bool nuevoEstado)
        {
            var result = new OperationResult();
            usuario.EstadoYFecha.Estado = nuevoEstado;
            result = await _usuarioRepository.UpdateEntityAsync(usuario);
            result.Message = $"Estado actualizado a {(nuevoEstado ? "activo" : "inactivo")}";
            return result;
        }
    }
}