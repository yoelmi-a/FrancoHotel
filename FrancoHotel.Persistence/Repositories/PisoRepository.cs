using System.Linq.Expressions;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Models.Models;
using FrancoHotel.Persistence.Base;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace FrancoHotel.Persistence.Repositories
{
    public class PisoRepository : BaseRepository<Piso, int>, IPisoRepository
    {
        private readonly HotelContext _context;
        private readonly ILogger<PisoRepository> _logger;
        private readonly IConfiguration _configuration;

        public PisoRepository(HotelContext context, 
                              ILogger<PisoRepository> logger, 
                              IConfiguration configuration) : base(context)
        {
            this._context = context;
            this._logger = logger;
            this._configuration = configuration;
        }

        public async Task<OperationResult> GetPisoByEstado(bool? estado)
        {
            OperationResult result = new OperationResult();
            try
            {
                var query = await (from piso in _context.Pisos
                                   where piso.EstadoYFecha.Estado == estado
                                   select new PisoModel()
                                   {
                                       IdPiso = piso.Id,
                                       Descripcion = piso.Descripcion,
                                       Estado = piso.EstadoYFecha.Estado,
                                       FechaCreacion = piso.EstadoYFecha.FechaCreacion
                                   }).ToListAsync();
                
                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorPisoRepository:GetPisoByEstado"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<List<Piso>> GetAllAsync()
        {
            return await _context.Pisos.ToListAsync();
        }

        public override async Task<bool> Exists(Expression<Func<Piso, bool>> filter)
        {
            return await _context.Pisos.AnyAsync(filter);
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Piso, bool>> filter)
        {
            OperationResult result = new OperationResult(); 
            result.Data = await _context.Pisos.Where(filter).ToListAsync();
            return result;
        }

        public override Task<Piso> GetEntityByIdAsync(int id)
        {
            if(id <= 0)
            {
                return null;
            }
            var piso = base.GetEntityByIdAsync(id);

            return piso;
        }

        public override async Task<OperationResult> SaveEntityAsync(Piso entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (entity == null)
                {
                    throw new Exception("El piso no debe ser nulo");
                }

                _context.Pisos.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorPisoRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override Task<OperationResult> UpdateEntityAsync(Piso entity)
        {
            return base.UpdateEntityAsync(entity);
        }
    }
}
