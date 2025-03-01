using System.Linq.Expressions;
using FrancoHotel.Application.Dtos.PisoDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FrancoHotel.Application.Services
{
    public class PisoService : IPisoService
    {
        private readonly IPisoRepository _pisoRepository;
        private readonly ILogger<PisoService> _logger;
        private readonly IConfiguration _configuration;

        public PisoService(IPisoRepository pisoRepository, 
                           ILogger<PisoService> logger,
                           IConfiguration configuration)
        {
            this._pisoRepository = pisoRepository;
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await _pisoRepository.GetAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public Task<OperationResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetPisoByEstado(bool? estado)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(RemovePisoDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Save(SavePisoDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(UpdatePisoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
