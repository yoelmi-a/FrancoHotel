using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Base;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace FrancoHotel.Persistence.Repositories
{
    internal class ServiciosRepository : BaseRepository<Servicios, short>, IServiciosRepository
    {
        private readonly HotelContext _context;
        private readonly ILogger<PisoRepository> _logger;
        private readonly IConfiguration _configuration;

        public ServiciosRepository(HotelContext context, 
                                   ILogger<PisoRepository> logger, 
                                   IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public override Task<bool> Exists(Expression<Func<Servicios, bool>> filter)
        {
            return base.Exists(filter);
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Servicios, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Servicios.Where(filter).AsNoTracking().ToListAsync();
            return result;
        }

        public override async Task<List<Servicios>> GetAllAsync()
        {
            return await _context.Servicios.AsNoTracking().ToListAsync();
        }

        public override async Task<Servicios> GetEntityByIdAsync(short id)
        {
            if (id <= 0)
            {
                return null;
            }

            return await _context.Servicios.FindAsync(id);
        }

        public override async Task<OperationResult> SaveEntityAsync(Servicios entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (string.IsNullOrWhiteSpace(entity.Descripcion) || string.IsNullOrWhiteSpace(entity.Nombre))
                { 
                    throw new ArgumentNullException("El servicio debe tener nombre y descripción");
                }

                _context.Servicios.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorServiciosRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(Servicios entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (string.IsNullOrWhiteSpace(entity.Descripcion) || string.IsNullOrWhiteSpace(entity.Nombre))
                {
                    throw new ArgumentNullException("El servicio debe tener nombre y descripción");
                }

                _context.Servicios.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorServiciosRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
    }
}
