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

        public override async Task<Habitacion> GetEntityByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return await _context.Habitacion.FindAsync(id).ConfigureAwait(false);
        }

        public override async Task<OperationResult> SaveEntityAsync(Habitacion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if(entity.Detalle.Length > 50)
                {
                    throw new ArgumentNullException("Los detalles no pueden pasar de 50 caracteres");
                }
                else if(entity.Precio <= 0)
                {
                    throw new ArgumentNullException("El precio de la habitacion debe ser mayor a 0");
                }
                else if(entity.IdPiso <= 0 || entity.IdCategoria <= 0)
                {
                    throw new ArgumentNullException("Los ids de piso y categoria deben ser mayores a 0");
                }
                else if (string.IsNullOrWhiteSpace(entity.Numero) 
                   || string.IsNullOrWhiteSpace(entity.Detalle) 
                   || !entity.EstadoYFecha.Estado.HasValue)
                {
                    throw new ArgumentNullException("La habitacion debe tener estado, número y detalles");
                }

                

                _context.Habitacion.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorHabitacionRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(Habitacion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                ValidationOfHabitacion(entity, result);
                if (!result.Success)
                {
                    result.Message = this._configuration["ErrorHabitacionRepository:InvalidData"];
                    return result;
                }
                _context.Habitacion.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorHabitacionRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        private static OperationResult ValidationOfHabitacion(Habitacion entity, OperationResult result)
        {
            if (entity.Precio <= 0)
            {
                result.Success = false;
                return result;
            }
            else if (entity.IdPiso <= 0 || entity.IdCategoria <= 0)
            {
                result.Success = false;
                return result;
            }
            else if (string.IsNullOrWhiteSpace(entity.Numero)
               || string.IsNullOrWhiteSpace(entity.Detalle)
               || !entity.EstadoYFecha.Estado.HasValue)
            {
                result.Success = false;
                return result;
            }

            return result;
        }

        public override async Task<OperationResult> RemoveEntityAsync(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                await _context.Habitacion.Where(e => e.Id == id).ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Borrado, true));
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["ErrorHabitacionRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
