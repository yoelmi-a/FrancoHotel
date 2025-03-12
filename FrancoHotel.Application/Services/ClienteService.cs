using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;

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

        public async Task<OperationResult> Remove(RemoveClienteDtos dto)
        {
            OperationResult result = new OperationResult();
            Cliente? cliente = await _clienteRepository.GetEntityByIdAsync(dto.IdCliente);
            if (cliente != null)
            {
                cliente.Borrado = true;
                result = await _clienteRepository.UpdateEntityAsync(cliente);
                return result;
            }
            else
            {
                result.Success = false;
                result.Message = "No se pudo encontrar el cliente a remover";
                return result;
            }
        }

        public async Task<OperationResult> Save(SaveClienteDtos dto)
        {
            OperationResult result = new OperationResult();

            if (!dto.Correo.Contains("@"))
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
            Cliente? cliente = await _clienteRepository.GetEntityByIdAsync(dto.IdCliente.Value);
            OperationResult result = new OperationResult();
            if (cliente != null)
            {
                if (!dto.Correo.Contains("@"))
                {
                    result.Success = false;
                    result.Message = "El formato del correo electrónico no es válido.";
                    return result;
                }

                result = await _clienteRepository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, cliente));
            }
            else
            {
                result.Success = false;
                result.Message = "El cliente a modificar no está registrado";
            }
            return result;
        }

        public async Task<OperationResult> UpdateEstado(Cliente entity, bool nuevoEstado)
        {
            OperationResult result = new OperationResult();
            entity.EstadoYFecha.Estado = nuevoEstado;
            result = await _clienteRepository.UpdateEntityAsync(entity);
            return result;
        }

        public async Task<OperationResult> UpdateTipoDocumento(Cliente entity)
        {
            OperationResult result = new OperationResult();
            result = await _clienteRepository.UpdateEntityAsync(entity);
            return result;
        }

        public async Task<OperationResult> GetHistorialReservas(int idCliente)
        {
            OperationResult result = new OperationResult();
            var reservas = await _recepcionRepository.GetAllAsync(r => r.IdCliente == idCliente);
            result.Data = reservas.Data;
            result.Success = true;
            return result;
        }
    }
}