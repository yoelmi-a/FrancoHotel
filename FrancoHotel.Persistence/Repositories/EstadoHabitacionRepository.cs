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
    public class EstadoHabitacionRepository : BaseRepository<EstadoHabitacion, int>, IEstadoHabitacionRepository
    {
        private readonly HotelContext _context;
        private readonly ILogger<EstadoHabitacionRepository> _logger;
        private readonly IConfiguration _configuration;

        public EstadoHabitacionRepository(HotelContext context,
                                   ILogger<EstadoHabitacionRepository> logger,
                                   IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public override async Task<bool> Exists(Expression<Func<EstadoHabitacion, bool>> filter)
        {
            return await _context.EstadoHabitacion.AnyAsync(filter);
        }

        public override async Task<List<EstadoHabitacion>> GetAllAsync()
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.EstadoHabitacion.Where(e => e.Borrado == false)
                                                           .AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result.Data;
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<EstadoHabitacion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.EstadoHabitacion.Where(filter)
                                                           .AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result;
        }

        public override async Task<EstadoHabitacion?> GetEntityByIdAsync(int id)
        {
            if (!RepoValidation.ValidarID(id))
            {
                return null;
            }
            return await _context.EstadoHabitacion.FindAsync(id);
        }

        public override async Task<OperationResult> SaveEntityAsync(EstadoHabitacion entity)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarEstadoHabitacion(entity))
            {
                result.Message = _configuration["ErrorEstadoHabitacionRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {

                _context.EstadoHabitacion.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorEstadoHabitacionRepository:SaveEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(EstadoHabitacion entity)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarEstadoHabitacion(entity) || !RepoValidation.ValidarID(entity.Id) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) || !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorEstadoHabitacionRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.EstadoHabitacion.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorEstadoHabitacionRepository:UpdateEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> RemoveEntityAsync(EstadoHabitacion entity)
        {
            OperationResult result = new OperationResult();

            if (!RepoValidation.ValidarEstadoHabitacion(entity) ||
                !RepoValidation.ValidarID(entity.Id) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!) ||
                !RepoValidation.ValidarID(entity.BorradoPorU) ||
                !RepoValidation.ValidarEntidad(entity.Borrado!))
            {
                result.Message = _configuration["ErrorEstadoHabitacionRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.EstadoHabitacion.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorEstadoHabitacionRepository:RemoveEntity"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
