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
                result.Message = "Usuario no encontrado";
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
                result.Message = "El rol especificado no existe";
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
            OperationResult result = new OperationResult();
            if (!dto.IdUsuario.HasValue)
            {
                result.Success = false;
                result.Message = "El ID del usuario es obligatorio";
                return result;
            }

            var usuarioExistente = await _usuarioRepository.GetEntityByIdAsync(dto.IdUsuario.Value);
            if (usuarioExistente == null || (usuarioExistente.Borrado ?? false))
            {
                result.Success = false;
                result.Message = "Usuario no encontrado";
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.Correo) || !dto.Correo.Contains("@"))
            {
                result.Success = false;
                result.Message = "Formato de correo inválido";
                return result;
            }

            if (await _usuarioRepository.Exists(u => u.Correo == dto.Correo && u.Id != dto.IdUsuario))
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

        public async Task<OperationResult> Remove(RemoveUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();
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

        public async Task<OperationResult> UpdateClave(Usuario usuario, string nuevaClave)
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(nuevaClave))
            {
                result.Success = false;
                result.Message = "La nueva contraseña no puede estar vacía";
                return result;
            }

            usuario.Clave = nuevaClave;
            result = await _usuarioRepository.UpdateEntityAsync(usuario);
            result.Message = "Contraseña actualizada correctamente";
            return result;
        }

        public async Task<OperationResult> UpdateEstado(Usuario usuario, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();
            usuario.EstadoYFecha.Estado = nuevoEstado;
            result = await _usuarioRepository.UpdateEntityAsync(usuario);
            result.Message = $"Estado actualizado a {(nuevoEstado ? "activo" : "inactivo")}";
            return result;
        }
    }
}