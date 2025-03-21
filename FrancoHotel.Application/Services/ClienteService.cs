using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Persistence.Repositories;

namespace FrancoHotel.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteMapper _mapper;
        private readonly ILogger<ClienteService> _logger;
        private readonly IConfiguration _configuration;
        private HotelContext mockContext;
        private ILogger<ClienteService> @object;
        private IConfigurationRoot mockConfiguration;

        public ClienteService(IClienteRepository clienteRepository,
                              IClienteMapper clienteMapper,
                              ILogger<ClienteService> logger,
                              IConfiguration configuration)
        {
            _clienteRepository = clienteRepository;
            _mapper = clienteMapper;
            _logger = logger;
            _configuration = configuration;
        }

        public ClienteService(HotelContext mockContext, ILogger<ClienteService> logger, IConfigurationRoot mockConfiguration)
        {
            this.mockContext = mockContext;
            this.@object = logger;
            this.mockConfiguration = mockConfiguration;
            this._configuration = mockConfiguration;
        }
        private bool EsNombreValido(string nombre) => !string.IsNullOrWhiteSpace(nombre) && Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");

        private bool EsDocumentoValido(string documento) => Regex.IsMatch(documento, @"^\d+$");

        private bool EsCorreoValido(string correo) => Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            var clientes = await _clienteRepository.GetAllAsync();
            result.Data = _mapper.DtoList(clientes);
            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.EntityToDto(await _clienteRepository.GetEntityByIdAsync(id));
            return result;
        }

        public async Task<OperationResult> GetClienteByDocumento(string documento)
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.EntityToDto(await _clienteRepository.GetClienteByDocumento(documento));
            return result;
        }

        public async Task<List<OperationResult>> GetClientesByEstado(bool estado)
        {
            var clientes = await _clienteRepository.GetClientesByEstado(estado);
            return clientes.Select(c => new OperationResult { Data = _mapper.EntityToDto(c) }).ToList();
        }

        public async Task<OperationResult> Save(SaveClienteDtos dto)
        {
            OperationResult result = new OperationResult();

            if (dto == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:DatosInvalidos"];
                return result;
            }

            if (!EsNombreValido(dto.NombreCompleto))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:NombreInvalido"];
                return result;
            }

            if (!EsDocumentoValido(dto.Documento))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:DocumentoInvalido"];
                return result;
            }

            if (!EsCorreoValido(dto.Correo))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:CorreoInvalido"];
                return result;
            }

            var entity = _mapper.SaveDtoToEntity(dto);
            result = await _clienteRepository.SaveEntityAsync(entity);
            return result;
        }

        public async Task<OperationResult> Update(UpdateClienteDtos dto)
        {
            OperationResult result = new OperationResult();

            if (dto == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:DatosInvalidos"];
                return result;
            }

            if (!EsNombreValido(dto.NombreCompleto))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:NombreInvalido"];
                return result;
            }

            if (!EsDocumentoValido(dto.Documento))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:DocumentoInvalido"];
                return result;
            }

            if (!EsCorreoValido(dto.Correo))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:CorreoInvalido"];
                return result;
            }

            Cliente? cliente = await _clienteRepository.GetEntityByIdAsync(dto.IdCliente);
            result = await _clienteRepository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, cliente));

            return result;
        }

        public async Task<OperationResult> Remove(RemoveClienteDtos dto)
        {
            OperationResult result = new OperationResult();


            Cliente? cliente = await _clienteRepository.GetEntityByIdAsync(dto.IdCliente);

            if (cliente == null || cliente.Borrado == true)
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:ClienteNoRegistradoOYaEliminado"];
                return result;
            }

            cliente.Borrado = true;
            result = await _clienteRepository.RemoveEntityAsync(_mapper.RemoveDtoToEntity(dto, cliente));

            return result;
        }

        public async Task<OperationResult> UpdateTipoDocumento(UpdateClienteDtos dto)
        {
            OperationResult result = new OperationResult();
            Cliente? existingCliente = await _clienteRepository.GetEntityByIdAsync(dto.IdCliente);

            if (!EsDocumentoValido(dto.Documento))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:DocumentoInvalido"];
                return result;
            }

            if (existingCliente == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:ClienteNoExiste"];
                return result;
            }

            if (string.IsNullOrEmpty(existingCliente.TipoDocumento))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:ClienteTipoDocumentoVacio"];
                return result;
            }

            existingCliente.TipoDocumento = dto.TipoDocumento;
            result = await _clienteRepository.UpdateEntityAsync(existingCliente);
            return result;
        }

        public async Task<OperationResult> UpdateEstado(UpdateClienteDtos dto, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();

            Cliente? cliente = await _clienteRepository.GetEntityByIdAsync(dto.IdCliente);

            if (cliente == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:ClienteNoExiste"];
                return result;
            }

            cliente.EstadoYFecha.Estado = nuevoEstado;
            result = await _clienteRepository.UpdateEntityAsync(cliente);
            return result;
        }
    }
}