

using System.Linq.Expressions;
using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace FrancoHotel.Application.Services
{
    public class RecepcionService : IRecepcionService
    {
        private readonly IRecepcionRepository _recepcionRepository;
        private readonly ILogger<RecepcionService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IRecepcionMapper _mapper;

        public RecepcionService(IRecepcionRepository recepcionRepository,
                                ILogger<RecepcionService> logger,
                                IConfiguration configuration,
                                IRecepcionMapper mapper)
        {
            _recepcionRepository = recepcionRepository;
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
        }


        public async Task<bool> Exists(Expression<Func<Recepcion, bool>> filter)
        {
            return await _recepcionRepository.Exists(filter);
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.DtoList(await _recepcionRepository.GetAllAsync());
            return result;
        }

        public async Task<OperationResult> GetAllByFilter(Expression<Func<Recepcion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _recepcionRepository.GetAllAsync(filter);
            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new OperationResult();
            result.Data = _mapper.EntityToDto(await _recepcionRepository.GetEntityByIdAsync(id));
            return result;
        }

        public async Task<OperationResult> Remove(RemoveRecepcionDto dto)
        {
            OperationResult result = new OperationResult();
            Recepcion? recepcion;


            if (RepoValidation.ValidarID(dto.Id))
            {
                recepcion = await _recepcionRepository.GetEntityByIdAsync(dto.Id);
                result = await _recepcionRepository.RemoveEntityAsync(_mapper.RemoveDtoToEntity(dto, recepcion));
                return result;
            }
            else
            {
                result.Success = false;
                result.Message = "La entidad es nula";
                return result;
            }
        }

        public async Task<OperationResult> Save(SaveRecepcionDto dto)
        {
            OperationResult result = new OperationResult();
            Expression<Func<Recepcion, bool>> filter = r => r.IdHabitacion == dto.IdHabitacion
            && dto.FechaEntrada <= r.FechaEntrada && r.FechaEntrada <= dto.FechaSalida
            || dto.FechaEntrada <= r.FechaSalida && r.FechaSalida <= dto.FechaEntrada;

            if (await _recepcionRepository.Exists(filter))
            {
                result.Success = false;
                result.Message = "ErrorRecepcionServise:ReservaExistente";
                return result;
            }
            if (dto.FechaEntrada > DateTime.Now ||
                dto.FechaSalida > dto.FechaEntrada
                )
            {
                result = await _recepcionRepository.SaveEntityAsync(_mapper.SaveDtoToEntity(dto));
            }
            else
            {
                result.Success = false;
                result.Message = "ErrorRecepcionServise:ErrorFecha";
            }
            return result;
        }

        public async Task<OperationResult> Update(UpdateRecepcionDto dto)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarID(dto.Id))
            {
                result.Success = false;
                return result;
            }

            Recepcion? recepcion = await _recepcionRepository.GetEntityByIdAsync(dto.Id);

            if (recepcion != null)
            {
                result = await _recepcionRepository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, recepcion));
            }
            else
            {
                result.Success = false;
                result.Message = "No se encontro la entidad";
            }
            return result;
        }
    }
}
