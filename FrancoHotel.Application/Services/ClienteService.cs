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

        public ClienteService(HotelContext mockContext, ILogger<ClienteService> @object, IConfigurationRoot mockConfiguration)
        {
            this.mockContext = mockContext;
            this.@object = @object;
            this.mockConfiguration = mockConfiguration;
        }

        private bool EsNombreValido(string nombre) =>
            !string.IsNullOrWhiteSpace(nombre) && Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");

        private bool EsDocumentoValido(string documento) =>
            Regex.IsMatch(documento, @"^\d+$");

        private bool EsCorreoValido(string correo) =>
            Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.DtoList(await _clienteRepository.GetAllAsync());
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

            if (await _clienteRepository.Exists(c => c.Correo == dto.Correo))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:CorreoDuplicado"];
                return result;
            }

            result = await _clienteRepository.SaveEntityAsync(_mapper.SaveDtoToEntity(dto));
            return result;
        }

        public async Task<OperationResult> Update(UpdateClienteDtos dto)
        {
            OperationResult result = new OperationResult();

            Cliente? cliente = await _clienteRepository.GetEntityByIdAsync(dto.IdCliente ?? 0);
            if (cliente == null || cliente.Borrado == true)
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:ClienteNoRegistradoOEliminado"];
                return result;
            }

            if (!EsNombreValido(dto.NombreCompleto) || !EsDocumentoValido(dto.Documento) || !EsCorreoValido(dto.Correo))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:DatosClienteInvalidos"];
                return result;
            }

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
            result = await _clienteRepository.UpdateEntityAsync(cliente);
            return result;
        }

        public async Task<OperationResult> UpdateTipoDocumento(Cliente entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null || string.IsNullOrEmpty(entity.TipoDocumento))
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:ClienteNuloOTipoDocumentoVacio"];
                return result;
            }

            Cliente? existingCliente = await _clienteRepository.GetEntityByIdAsync(entity.Id);
            if (existingCliente == null)
            {
                result.Success = false;
                result.Message = _configuration["ErrorClienteService:ClienteNoExiste"];
                return result;
            }

            existingCliente.TipoDocumento = entity.TipoDocumento;
            result = await _clienteRepository.UpdateEntityAsync(existingCliente);
            return result;
        }

        public async Task<OperationResult> UpdateEstado(Cliente entity, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();

            Cliente? cliente = await _clienteRepository.GetEntityByIdAsync(entity.Id);
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
