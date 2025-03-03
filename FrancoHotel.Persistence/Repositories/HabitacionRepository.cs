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
    public class HabitacionRepository : BaseRepository<Habitacion, int>, IHabitacionRepository
    {
        private readonly HotelContext _context;
        private readonly ILogger<PisoRepository> _logger;
        private readonly IConfiguration _configuration;

        public HabitacionRepository(HotelContext context,
                                   ILogger<PisoRepository> logger,
                                   IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public override async Task<bool> Exists(Expression<Func<Habitacion, bool>> filter)
        {
            return await _context.Habitacion.AnyAsync(filter).ConfigureAwait(false);
        }

        public override async Task<List<Habitacion>> GetAllAsync()
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Habitacion.AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result.Data;
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Habitacion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Habitacion.Where(filter)
                                                           .AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result;
        }

        public override async Task<Habitacion?> GetEntityByIdAsync(int id)
        {
            if(!RepoValidation.ValidarID(id))
            {
                return null;
            }
            return await _context.Habitacion.FindAsync(id).ConfigureAwait(false);
        }

        public override async Task<OperationResult> SaveEntityAsync(Habitacion entity)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarHabitacion(entity))
            {
                result.Message = _configuration["ErrorHabitacionRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {

                _context.Habitacion.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorHabitacionRepository:SaveEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(Habitacion entity)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarID(entity.Id) || !RepoValidation.ValidarHabitacion(entity) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) || !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorHabitacionRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Habitacion.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorHabitacionRepository:UpdateEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
