using System.Linq.Expressions;
using AutoMapper;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FrancoHotel.Application.Services
{
    public class PisoService : IPisoService
    {
        private readonly IPisoRepository _pisoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRecepcionRepository _recepcionRepository;
        private readonly ILogger<PisoService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PisoService(IPisoRepository pisoRepository, 
                           ILogger<PisoService> logger,
                           IConfiguration configuration,
                           IMapper mapper,
                           IUsuarioRepository usuarioRepository,
                           IRecepcionRepository recepcionRepository)
        {
            this._pisoRepository = pisoRepository;
            this._logger = logger;
            this._configuration = configuration;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _recepcionRepository = recepcionRepository;
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            result.Data = await _pisoRepository.GetAllAsync();

            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new OperationResult();
            result.Data = await _pisoRepository.GetEntityByIdAsync(id);
            return result;
        }

        public async Task<OperationResult> Remove(RemovePisoDto dto)
        {
            OperationResult result = new OperationResult();
            bool hasReservations = await _recepcionRepository.GetHabitacionInPisoBooked(dto.Id);
            if (hasReservations)
            {
                result.Success = false;
                result.Message = "El piso no se puede remover porque tiene reservas activas";
                return result;
            }

            Piso? piso = await _pisoRepository.GetEntityByIdAsync(dto.Id);
            if (piso != null)
            {
                result = await _pisoRepository.RemoveEntityAsync(_mapper.Map(dto, piso));
            }

            return result;
        }

        public async Task<OperationResult> Save(SavePisoDto dto)
        {
            OperationResult result = new OperationResult();
            result = await _pisoRepository.SaveEntityAsync(_mapper.Map<Piso>(dto));
            return result;
        }

        public async Task<OperationResult> Update(UpdatePisoDto dto)
        {
            Piso? piso = await _pisoRepository.GetEntityByIdAsync(dto.Id);
            OperationResult result = new OperationResult();
            if (piso != null)
            {
                result = await _pisoRepository.UpdateEntityAsync(_mapper.Map(dto, piso));
            }
            result.Success = false;
            result.Message = "El piso a modificar no está registrado";
            return result;
        }
    }
}
