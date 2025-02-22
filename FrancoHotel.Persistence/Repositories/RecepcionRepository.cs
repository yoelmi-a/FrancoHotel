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
            try
            {
                if (entity.Id <= 0 || entity.IdCliente <= 0 || entity.IdHabitacion <= 0)
                {
                    throw new ArgumentException("Los valores de ID deben ser mayores a 0.");
                }

                await _context.Recepciones.AddAsync(entity);
                await _context.SaveChangesAsync();

                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorRecepcionRepository:AddRecepcionAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> UpdateEntityAsync(Recepcion updatedRecepcion)
        {
            OperationResult result = new OperationResult();
            try
            {
                var recepcion = await _context.Recepciones.FindAsync(updatedRecepcion.Id);
                if (recepcion == null)
                {
                    result.Message = "Recepción no encontrada";
                    result.Success = false;
                    return result;
                }

                recepcion.IdCliente = updatedRecepcion.IdCliente;
                recepcion.IdHabitacion = updatedRecepcion.IdHabitacion;
                recepcion.FechaEntrada = updatedRecepcion.FechaEntrada;
                recepcion.FechaSalida = updatedRecepcion.FechaSalida;
                recepcion.FechaSalidaConfirmacion = updatedRecepcion.FechaSalidaConfirmacion;
                recepcion.PrecioInicial = updatedRecepcion.PrecioInicial;
                recepcion.Adelanto = updatedRecepcion.Adelanto;
                recepcion.PrecioRestante = updatedRecepcion.PrecioRestante;
                recepcion.TotalPagado = updatedRecepcion.TotalPagado;
                recepcion.CostoPenalidad = updatedRecepcion.CostoPenalidad;
                recepcion.Obsevacion = updatedRecepcion.Obsevacion;
                recepcion.Estado = updatedRecepcion.Estado;

                await _context.SaveChangesAsync();
                result.Data = recepcion;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorRecepcionRepository:EditRecepcionAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<Recepcion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Recepciones.Where(filter)
                                                           .AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result;
        }
        public override async Task<List<Recepcion>> GetAllAsync()
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Recepciones.AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result.Data;
        }
        public override async Task<bool> Exists(Expression<Func<Recepcion, bool>> filter)
        {
            return await _context.Recepciones.AnyAsync(filter).ConfigureAwait(false);
        }
        public override async Task<Recepcion> GetEntityByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return await _context.Recepciones.FindAsync(id).ConfigureAwait(false);
        }
    }
}
