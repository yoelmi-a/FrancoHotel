﻿using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

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

        private bool EsNombreValido(string nombre) => !string.IsNullOrWhiteSpace(nombre) && Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");

        private bool EsCorreoValido(string correo) => Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

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
                result.Message = _configuration["ErrorUsuarioService:UsuarioNoEncontrado"];
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
                result.Message = _configuration["ErrorUsuarioService:RolNoExiste"];
            }

            var usuarios = await _usuarioRepository.GetUsuarioByIdRolUsuario(idRolUsuario);
            var usuariosSinBorrados = usuarios.Where(u => !(u.Borrado ?? false)).ToList();
            result.Data = _mapper.DtoList(usuariosSinBorrados);
            return result;
        }

        public async Task<OperationResult> GetUsuariosByEstado(bool estado)
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.DtoList(await _usuarioRepository.GetUsuariosByEstado(estado));
            return result;
        }

        public async Task<OperationResult> Save(SaveUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();

            if (dto == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioService:DatosInvalidos"];
                return result;
            }

            if (!EsNombreValido(dto.NombreCompleto))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioService:NombreInvalido"];
                return result;
            }

            if (!EsCorreoValido(dto.Correo))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioService:CorreoInvalido"];
                return result;
            }

            var nuevoUsuario = _mapper.SaveDtoToEntity(dto);
            result = await _usuarioRepository.SaveEntityAsync(nuevoUsuario);
            result.Data = dto;
            return result;
        }

        public async Task<OperationResult> Update(UpdateUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();
            if (dto == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioService:DatosInvalidos"];
                return result;
            }

            if (dto.IdUsuario <= 0)
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioService:IdObligatorio"];
                return result;
            }

            var usuarioExistente = await _usuarioRepository.GetEntityByIdAsync(dto.IdUsuario);
            if (usuarioExistente == null || (usuarioExistente.Borrado ?? false))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioService:UsuarioNoEncontrado"];
                return result;
            }

            if (!EsCorreoValido(dto.Correo))
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioService:CorreoInvalido"];
                return result;
            }

            var usuarioActualizado = _mapper.UpdateDtoToEntity(dto, usuarioExistente);
            result = await _usuarioRepository.UpdateEntityAsync(usuarioActualizado);
            result.Data = dto;
            return result;
        }

        public async Task<OperationResult> Remove(RemoveUsuarioDtos dto)
        {
            OperationResult result = new OperationResult();
            var usuario = await _usuarioRepository.GetEntityByIdAsync(dto.IdUsuario);

            if (usuario == null || usuario.Borrado == true)
            {
                result.Success = false;
                result.Message = _configuration["ErrorUsuarioService:UsuarioNoRegistradoOYaEliminado"];
                return result;
            }

            usuario.Borrado = true;
            result = await _usuarioRepository.RemoveEntityAsync(_mapper.RemoveDtoToEntity(dto, usuario));

            return result;
        }
    }
}
