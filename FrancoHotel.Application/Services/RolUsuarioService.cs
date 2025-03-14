using FrancoHotel.Application.Dtos.RolUsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FrancoHotel.Application.Services
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IRolUsuarioRepository _rolUsuarioRepository;
        private readonly IRolUsuarioMapper _mapper;
        private readonly IConfiguration _configuration;

        public RolUsuarioService(
            IRolUsuarioRepository rolUsuarioRepository,
            IRolUsuarioMapper mapper,
            IConfiguration configuration)
        {
            _rolUsuarioRepository = rolUsuarioRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            var roles = await _rolUsuarioRepository.GetAllAsync();
            result.Data = _mapper.DtoList(roles.Where(r => !(r.Borrado ?? false)).ToList());
            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new OperationResult();
            var rol = await _rolUsuarioRepository.GetEntityByIdAsync(id);

            if (rol == null || (rol.Borrado ?? false))
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:RolNoEncontrado"];
                return result;
            }

            result.Data = _mapper.EntityToDto(rol);
            return result;
        }

        public async Task<List<OperationResult>> GetRolesUsuarioByEstado(bool estado)
        {
            var roles = await _rolUsuarioRepository.GetRolesUsuarioByEstado(estado);
            return roles.Where(r => !(r.Borrado ?? false))
                        .Select(r => new OperationResult { Data = _mapper.EntityToDto(r) })
                        .ToList();
        }

        public async Task<OperationResult> GetRolUsuarioByDescripcion(string descripcion)
        {
            OperationResult result = new OperationResult();
            var rol = await _rolUsuarioRepository.GetRolUsuarioByDescripcion(descripcion);

            if (rol == null || (rol.Borrado ?? false))
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:RolNoEncontrado"];
                return result;
            }

            result.Data = _mapper.EntityToDto(rol);
            return result;
        }

        public async Task<OperationResult> Save(SaveRolUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(dto.Descripcion))
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:DescripcionVacia"];
                return result;
            }

            if (await _rolUsuarioRepository.Exists(r => r.Descripcion == dto.Descripcion))
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:DescripcionDuplicada"];
                return result;
            }

            var nuevoRol = _mapper.SaveDtoToEntity(dto);
            result = await _rolUsuarioRepository.SaveEntityAsync(nuevoRol);
            return result;
        }

        public async Task<OperationResult> Update(UpdateRolUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();

            if (!dto.IdRolUsuario.HasValue)
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:IdObligatorio"];
                return result;
            }

            var rolExistente = await _rolUsuarioRepository.GetEntityByIdAsync(dto.IdRolUsuario.Value);

            if (rolExistente == null || (rolExistente.Borrado ?? false))
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:RolNoEncontrado"];
                return result;
            }

            if (string.IsNullOrWhiteSpace(dto.Descripcion))
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:DescripcionVacia"];
                return result;
            }

            if (await _rolUsuarioRepository.Exists(r =>
                    r.Descripcion == dto.Descripcion &&
                    r.Id != dto.IdRolUsuario))
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:DescripcionDuplicadaOtroRol"];
                return result;
            }

            var rolActualizado = _mapper.UpdateDtoToEntity(dto, rolExistente);
            result = await _rolUsuarioRepository.UpdateEntityAsync(rolActualizado);
            return result;
        }

        public async Task<OperationResult> Remove(RemoveRolUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();
            var rol = await _rolUsuarioRepository.GetEntityByIdAsync(dto.IdRolUsuario);

            if (rol == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:RolNoEncontrado"];
                return result;
            }

            rol.Borrado = true;
            result = await _rolUsuarioRepository.UpdateEntityAsync(rol);
            return result;
        }

        public async Task<OperationResult> UpdateDescripcion(RolUsuario rol, string nuevaDescripcion)
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(nuevaDescripcion))
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:NuevaDescripcionVacia"];
                return result;
            }

            if (await _rolUsuarioRepository.Exists(r =>
                    r.Descripcion == nuevaDescripcion &&
                    r.Id != rol.Id))
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuario:DescripcionEnUsoOtroRol"];
                return result;
            }

            rol.Descripcion = nuevaDescripcion;
            result = await _rolUsuarioRepository.UpdateEntityAsync(rol);
            return result;
        }
        public async Task<OperationResult> UpdateEstado(RolUsuario rol, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();

            RolUsuario rolUsuario = await _rolUsuarioRepository.GetEntityByIdAsync(rol.Id);
            if (rolUsuario == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorRolUsuarioService:RolNoExiste"];
                return result;
            }

            rolUsuario.EstadoYFecha.Estado = nuevoEstado;
            result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);
            return result;
        }

    }
}
