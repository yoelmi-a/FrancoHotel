

using System.Linq.Expressions;
using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            result.Data = await _recepcionRepository.GetAllAsync();
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
            result.Data = await _recepcionRepository.GetEntityByIdAsync(id);
            return result;
        }

        public async Task<OperationResult> Remove(RemoveRecepcionDto dto)
        {
            OperationResult result = new OperationResult();
            Recepcion? recepcion = await _recepcionRepository.GetEntityByIdAsync(dto.Id);


            if (recepcion != null)
            {
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
            result = await _recepcionRepository.SaveEntityAsync(_mapper.SaveDtoToEntity(dto));
            return result;
        }

        public Task<OperationResult> TotalTarifa(int IdCategoria, int Days, int? ServiciosAdicionales)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Update(UpdateRecepcionDto dto)
        {
            OperationResult result = new OperationResult();
            Recepcion? recepcion = await _recepcionRepository.GetEntityByIdAsync(dto.Id);
            if (recepcion != null)
            {
                result = await _recepcionRepository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, recepcion));

            }
            return result;
        }

        public Task<OperationResult> UpdateTarifaByCategoria(string IdCategoria, decimal Precio)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateTarifasByFechas(DateTime FechaInicio, DateTime FechaFinal, decimal porcentajeCambio)
        {
            throw new NotImplementedException();
        }
    }
}
