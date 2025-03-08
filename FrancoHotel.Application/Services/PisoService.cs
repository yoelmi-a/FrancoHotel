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
        private readonly ILogger<PisoService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PisoService(IPisoRepository pisoRepository, 
                           ILogger<PisoService> logger,
                           IConfiguration configuration,
                           IMapper mapper,
                           IUsuarioRepository usuarioRepository)
        {
            this._pisoRepository = pisoRepository;
            this._logger = logger;
            this._configuration = configuration;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
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

        public Task<OperationResult> GetPisoByEstado(bool? estado)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(RemovePisoDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Save(SavePisoDto dto)
        {
            OperationResult result = new OperationResult();
            if()
            result = await _pisoRepository.SaveEntityAsync(_mapper.Map<Piso>(dto));
            return result;
        }

        public Task<OperationResult> Update(UpdatePisoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
