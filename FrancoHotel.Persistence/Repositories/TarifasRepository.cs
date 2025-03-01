using System.Linq.Expressions;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Base;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.Data.SqlClient;
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

        public async Task<OperationResult> AddTarifaByCategoria(string categoria, double precio)
        {
            OperationResult result = new OperationResult();
            try
            {
                var tarifas = await _context.Tarifas
                    .Join(_context.Habitacion,
                        t => t.IdHabitacion,
                        h => h.Id,
                        (t, h) => new { t, h })
                    .Join(_context.Categoria,
                        th => th.h.IdCategoria,
                        c => c.Id,
                        (th, c) => new { th.t, th.h, c })
                    .Where(x => x.c.Descripcion == categoria)
                    .ToListAsync();

                foreach (var tarifa in tarifas)
                {
                    tarifa.t.PrecioPorNoche = (decimal)precio;
                }

                await _context.SaveChangesAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorTarifasRepository:AddTarifaByCategoria"];
                result.Success = false;
                Console.WriteLine(result.Message + $": {ex.Message}");
            }
            return result;
        }




        public async Task<OperationResult> UpdateTarifasByFechas(DateTime fechaInicio, DateTime fechaFin, double porcentajeCambio)
        {
            OperationResult result = new OperationResult();

            try
            {
                var parametros = new[]
                {
                    new SqlParameter("@FechaInicio", fechaInicio),
                    new SqlParameter("@FechaFin", fechaFin),
                    new SqlParameter("@PorcentajeCambio", porcentajeCambio)
                };

                await _context.Database.ExecuteSqlRawAsync("EXEC AjustarTarifas @FechaInicio, @FechaFin, @PorcentajeCambio", parametros);

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorTarifasRepository:UpdateTarifasByFechas"];
                result.Success = false;
                Console.WriteLine(result.Message + $": {ex.Message}");
            }

            return result;
        }



        public async Task<OperationResult> TotalTarifa(int IdCategoria, int Days, int? ServiciosAdicionales)
        {
            OperationResult result = new OperationResult();

            try
            {
                // Obtener la categoría de habitación
                var categoria = await _context.Categoria
                    .FirstOrDefaultAsync(c => c.Id == IdCategoria);

                if (categoria == null)
                {
                    result.Message = "Categoría no encontrada.";
                    result.Success = false;
                    return result;
                }

                // Obtener la tarifa correspondiente a la categoría
                var tarifa = await _context.Tarifas
                    .Where(t => t.IdHabitacion == categoria.Id && t.Estado == null)
                    .FirstOrDefaultAsync();

                if (tarifa == null)
                {
                    result.Message = "Tarifa no encontrada.";
                    result.Success = false;
                    return result;
                }

                // Calcular el costo de hospedaje
                double costoHospedaje = Days * (double)tarifa.PrecioPorNoche;

                // Calcular el total con servicios adicionales
                double totalConServicios = costoHospedaje;

                if (ServiciosAdicionales.HasValue)
                {
                    totalConServicios += ServiciosAdicionales.Value * 20; // Ajusta el costo según sea necesario.
                }

                result.Success = true;
                result.Data = new
                {
                    CostoHospedaje = costoHospedaje,
                    TotalConServicios = totalConServicios
                };
            }
            catch (Exception ex)
            {
                result.Message = "Error al calcular la tarifa.";
                result.Success = false;
                Console.WriteLine(result.Message + $": {ex.Message}");
            }

            return result;
        }
        public override async Task<bool> Exists(Expression<Func<Tarifas, bool>> filter)
        {
            return await _context.Tarifas.AnyAsync(filter).ConfigureAwait(false);
        }

        public override async Task<List<Tarifas>> GetAllAsync()
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Tarifas.AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result.Data;
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Tarifas, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Tarifas.Where(filter)
                                                           .AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result;
        }

        public override async Task<Tarifas> GetEntityByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return await _context.Tarifas.FindAsync(id).ConfigureAwait(false);
        }

        public override async Task<OperationResult> SaveEntityAsync(Tarifas entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                /*
                if (entity.IdHabitacion >= 0)
                {
                }
                else if (entity.IdHabitacion >= 0)
                {
                }
                */
                _context.Tarifas.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                result.Message = this._configuration["ErrorTarifasRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message);
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(Tarifas entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (entity.Id >= 0)
                {

                }
                if (entity.IdHabitacion >= 0)
                {

                }
                if (entity.IdHabitacion >= 0)
                {

                }

                _context.Tarifas.Update(entity);
                await _context.SaveChangesAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
