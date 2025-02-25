﻿using System.Linq.Expressions;
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
        private readonly ILogger<PisoRepository> _logger;
        private readonly IConfiguration _configuration;

        public EstadoHabitacionRepository(HotelContext context,
                                   ILogger<PisoRepository> logger,
                                   IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public override async Task<bool> Exists(Expression<Func<EstadoHabitacion, bool>> filter)
        {
            return await _context.EstadoHabitaciones.AnyAsync(filter);
        }

        public override async Task<List<EstadoHabitacion>> GetAllAsync()
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.EstadoHabitaciones.AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result.Data;
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<EstadoHabitacion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.EstadoHabitaciones.Where(filter)
                                                           .AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result;
        }

        public override async Task<EstadoHabitacion> GetEntityByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return await _context.EstadoHabitaciones.FindAsync(id);
        }

        public override async Task<OperationResult> SaveEntityAsync(EstadoHabitacion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (string.IsNullOrWhiteSpace(entity.Descripcion) || !entity.EstadoYFecha.Estado.HasValue)
                {
                    throw new ArgumentNullException("El estado de la habitacion debe tener estado y descripción");
                }

                _context.EstadoHabitaciones.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorEstadoHabitacionRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(EstadoHabitacion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (string.IsNullOrWhiteSpace(entity.Descripcion) || !entity.EstadoYFecha.Estado.HasValue)
                {
                    throw new ArgumentNullException("El estado de la habitacion debe tener estado y descripción");
                }

                _context.EstadoHabitaciones.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorEstadoHabitacionRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
