using FrancoHotel.Application.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.TarifasDto;
using FrancoHotel.Application.Dtos.TarifasDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Repositories;
using System.Linq.Expressions;

namespace FrancoHotel.Application.Services
{
    public class TarifasService : ITarifasService
    {
        private readonly ITarifasRepository _tarifasRepository;
        private readonly ILogger<TarifasService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITarifasMapper _mapper;

        public TarifasService(ITarifasRepository tarifasRepository,
                                ILogger<TarifasService> logger,
                                IConfiguration configuration,
                                ITarifasMapper mapper)
        {
            _tarifasRepository = tarifasRepository;
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<bool> Exists(Expression<Func<Tarifas, bool>> filter)
        {
            return await _tarifasRepository.Exists(filter);
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            result.Data = await _tarifasRepository.GetAllAsync();
            return result;
        }

        public async Task<OperationResult> GetAllByFilter(Expression<Func<Tarifas, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _tarifasRepository.GetAllAsync(filter);
            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new OperationResult();
            result.Data = await _tarifasRepository.GetEntityByIdAsync(id);
            return result;
        }

        public async Task<OperationResult> Remove(RemoveTarifasDto dto)
        {
            OperationResult result = new OperationResult();
            Tarifas? tarifas = await _tarifasRepository.GetEntityByIdAsync(dto.Id);
            result = await _tarifasRepository.RemoveEntityAsync(_mapper.RemoveDtoToEntity(dto, tarifas));
            return result;
        }

        public async Task<OperationResult> Save(SaveTarifasDtos dto)
        {

            OperationResult result = new OperationResult();
            result = await _tarifasRepository.SaveEntityAsync(_mapper.SaveDtoToEntity(dto));
            return result;
        }

        public async Task<OperationResult> TotalTarifa(int IdCategoria, int Days, int? ServiciosAdicionales)
        {
            OperationResult result = new OperationResult();
            result.Data = await _tarifasRepository.TotalTarifa(IdCategoria, Days, ServiciosAdicionales);
            return result;
        }

        public async Task<OperationResult> Update(UpdateTarifasDto dto)
        {
            OperationResult result = new OperationResult();
            Tarifas? tarifas = await _tarifasRepository.GetEntityByIdAsync(dto.Id);
            if (tarifas != null)
            {
                result = await _tarifasRepository.UpdateEntityAsync(_mapper.UpdateDtoToEntity(dto, tarifas));

            }
            return result;
        }

        public async Task<OperationResult> UpdateTarifaByCategoria(string IdCategoria, decimal Precio)
        {
            OperationResult result = new OperationResult();
            result.Data = await _tarifasRepository.UpdateTarifaByCategoria(IdCategoria, Precio);
            return result;
        }

        public async Task<OperationResult> UpdateTarifasByFechas(DateTime FechaInicio, DateTime FechaFinal, decimal porcentajeCambio)
        {
            OperationResult result = new OperationResult();
            result.Data = await _tarifasRepository.UpdateTarifasByFechas(FechaInicio, FechaFinal, porcentajeCambio);
            return result;
        }
    }
}
