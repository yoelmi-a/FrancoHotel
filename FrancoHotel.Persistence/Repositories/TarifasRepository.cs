using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Base;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace FrancoHotel.Persistence.Repositories
{
    public class TarifasRepository : BaseRepository<Tarifas, int>, ITarifasRepository
    {
        private readonly HotelContext _context;
        private readonly ILogger<TarifasRepository> _logger;
        private readonly IConfiguration _configuration;
        public TarifasRepository(HotelContext context,
                              ILogger<TarifasRepository> logger,
                              IConfiguration configuration) : base(context)
        {
            this._context = context;
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task<OperationResult> AddTarifaByCategoria(string categoria, double Precio)
        {
            throw new NotImplementedException();
        }


        public async Task<OperationResult> UpdateTarifasByFechas(DateTime fechaInicio, DateTime fechaFin, double porcentajeCambio)
        {
            throw new NotImplementedException();
        }


        public Task<OperationResult> TotalTarifa(int IdCategoria)
        {
            throw new NotImplementedException();
        }


        public Task<OperationResult> UpdateTarifa(int IdCategoria, double Precio)
        {
            throw new NotImplementedException();
        }
    }
}
