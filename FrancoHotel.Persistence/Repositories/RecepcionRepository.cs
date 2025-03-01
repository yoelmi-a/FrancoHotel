using System.Linq;
using System.Linq.Expressions;
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
    public class RecepcionRepository : BaseRepository<Recepcion, int>, IRecepcionRepository
    {
        private readonly HotelContext _context;
        private readonly ILogger<RecepcionRepository> _logger;
        private readonly IConfiguration _configuration;

        public RecepcionRepository(HotelContext context,
                              ILogger<RecepcionRepository> logger,
                              IConfiguration configuration) : base(context)
        {
            this._context = context;
            this._logger = logger;
            this._configuration = configuration;

        }
        public override async Task<OperationResult> SaveEntityAsync(Recepcion entity)
        {
            OperationResult result = new OperationResult();
            

                await _context.Recepcion.AddAsync(entity);
                await _context.SaveChangesAsync();

                result.Data = entity;

            return result;
        }



        public override async Task<OperationResult> UpdateEntityAsync(Recepcion entity)
        {
            OperationResult result = new OperationResult();

            if (entity.Id >= 0)
            {

            }
            try
            {


                _context.Recepcion.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRecepcionRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Recepcion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Recepcion.Where(filter)
                                                           .AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result;
        }

        public override async Task<List<Recepcion>> GetAllAsync()
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Recepcion.AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result.Data;
        }
        public override async Task<bool> Exists(Expression<Func<Recepcion, bool>> filter)
        {
            return await _context.Recepcion.AnyAsync(filter).ConfigureAwait(false);
        }
        public override async Task<Recepcion> GetEntityByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return await _context.Recepcion.FindAsync(id).ConfigureAwait(false);
        }

        
    }
}
