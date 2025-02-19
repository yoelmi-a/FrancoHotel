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
        public async Task<OperationResult> SaveEntityAsync(Recepcion recepcion)
        {
            OperationResult result = new OperationResult();
            try
            {
                await _context.Recepciones.AddAsync(recepcion);
                await _context.SaveChangesAsync();

                result.Data = recepcion;
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorRecepcionRepository:AddRecepcionAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public async Task<OperationResult> UpdateRecepcion(int id, Recepcion updatedRecepcion)
        {
            OperationResult result = new OperationResult();
            try
            {
                var recepcion = await _context.Recepciones.FindAsync(id);
                if (recepcion == null)
                {
                    result.Message = "Recepción no encontrada";
                    result.Success = false;
                    return result;
                }

                // Actualizar los campos necesarios
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
                // Agregar otros campos si es necesario

                await _context.SaveChangesAsync();
                result.Data = recepcion;
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorRecepcionRepository:EditRecepcionAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

    }
}
