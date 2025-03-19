using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using System.Text.RegularExpressions;

namespace FrancoHotel.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IRecepcionRepository _recepcionRepository;
        private readonly IClienteMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IRecepcionRepository recepcionRepository, IClienteMapper clienteMapper)
        {
            _clienteRepository = clienteRepository;
            _recepcionRepository = recepcionRepository;
            _mapper = clienteMapper;
        }

        private bool EsNombreValido(string nombre) =>
            !string.IsNullOrWhiteSpace(nombre) && Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");

        private bool EsDocumentoValido(string documento) =>
            Regex.IsMatch(documento, @"^\d+$");

        private bool EsCorreoValido(string correo) =>
            Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public async Task<OperationResult> Save(SaveClienteDtos dto)
        {
            OperationResult result = new OperationResult();

            if (!EsNombreValido(dto.NombreCompleto))
            {
                result.Success = false;
                result.Message = "El nombre solo debe contener letras y no puede estar vacío.";
                return result;
            }

            if (!EsDocumentoValido(dto.Documento))
            {
                result.Success = false;
                result.Message = "El documento de identidad solo debe contener números.";
                return result;
            }

            if (!EsCorreoValido(dto.Correo))
            {
                result.Success = false;
                result.Message = "El formato del correo electrónico no es válido.";
                return result;
            }

            if (await _clienteRepository.Exists(c => c.Correo == dto.Correo))
            {
                result.Success = false;
                result.Message = "El correo electrónico ya está registrado.";
                return result;
            }

            result = await _clienteRepository.SaveEntityAsync(_mapper.SaveDtoToEntity(dto));
            return result;
        }

        public async Task<OperationResult> Update(UpdateClienteDtos dto)
        {
            OperationResult result = new OperationResult();

            if (!dto.IdCliente.HasValue)
            {
                result.Success = false;
                result.Message = "El ID del cliente es obligatorio.";
                return result;
            }

            Cliente? cliente = await _clienteRepository.GetEntityByIdAsync(dto.IdCliente.Value);
            if (cliente == null)
            {
                result.Success = false;
                result.Message = "El cliente a modificar no está registrado.";
                return result;
            }

            if (cliente.Borrado ?? false)
            {
                result.Success = false;
                result.Message = "No se pueden modificar clientes eliminados.";
                return result;
            }

            if (!EsNombreValido(dto.NombreCompleto) || !EsDocumentoValido(dto.Documento) || !EsCorreoValido(dto.Correo))
            {
                result.Success = false;
                result.Message = "Datos de cliente no válidos.";
                return result;
            }

            result = await _clienteRepository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, cliente));
            return result;
        }

        public async Task<OperationResult> UpdateEstado(Cliente entity, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();

            if (entity.Borrado ?? false)
            {
                result.Success = false;
                result.Message = "No se pueden modificar clientes eliminados.";
                return result;
            }

            entity.EstadoYFecha.Estado = nuevoEstado;
            result = await _clienteRepository.UpdateEntityAsync(entity);
            return result;
        }

        public async Task<OperationResult> Remove(RemoveClienteDtos dto)
        {
            OperationResult result = new OperationResult();

            Cliente? cliente = await _clienteRepository.GetEntityByIdAsync(dto.IdCliente);
            if (cliente == null)
            {
                result.Success = false;
                result.Message = "No se pudo encontrar el cliente a remover.";
                return result;
            }

            if (cliente.Borrado ?? false)
            {
                result.Success = false;
                result.Message = "El cliente ya está eliminado.";
                return result;
            }

            cliente.Borrado = true;
            result = await _clienteRepository.UpdateEntityAsync(cliente);
            return result;
        }

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
            var cliente = await _clienteRepository.GetEntityByIdAsync(id);
            result.Data = _mapper.EntityToDto(cliente);
            return result;
        }

        public async Task<OperationResult> GetClienteByDocumento(string documento)
        {
            OperationResult result = new OperationResult();
            var cliente = await _clienteRepository.GetClienteByDocumento(documento);
            result.Data = _mapper.EntityToDto(cliente);
            return result;
        }

        public async Task<List<OperationResult>> GetClientesByEstado(bool estado)
        {
            var clientes = await _clienteRepository.GetClientesByEstado(estado);
            return clientes.Select(c => new OperationResult { Data = _mapper.EntityToDto(c) }).ToList();
        }

        public async Task<OperationResult> UpdateTipoDocumento(Cliente entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "El cliente proporcionado es nulo.";
                    return result;
                }

                var existingCliente = await _clienteRepository.GetEntityByIdAsync(entity.Id);
                if (existingCliente == null)
                {
                    result.Success = false;
                    result.Message = "El cliente no existe en la base de datos.";
                    return result;
                }

                if (string.IsNullOrEmpty(entity.TipoDocumento))
                {
                    result.Success = false;
                    result.Message = "El tipo de documento no puede estar vacío.";
                    return result;
                }

                existingCliente.TipoDocumento = entity.TipoDocumento;
                result = await _clienteRepository.UpdateEntityAsync(existingCliente);
                result.Success = true;
                result.Message = "Tipo de documento actualizado correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error al actualizar el tipo de documento: {ex.Message}";
            }

            return result;
        }
    }
}