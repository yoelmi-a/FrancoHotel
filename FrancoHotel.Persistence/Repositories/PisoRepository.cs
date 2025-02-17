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

            var query = await (from piso in _context.Pisos
                                   where piso.EstadoYFecha.Estado == estado
                                   select new PisoModel()
                                   {
                                       IdPiso = piso.Id,
                                       Descripcion = piso.Descripcion,
                                       Estado = piso.EstadoYFecha.Estado,
                                       FechaCreacion = piso.EstadoYFecha.FechaCreacion
                                   }).AsNoTracking().ToListAsync();
                
            result.Data = query;
            return result;
        }

        public override async Task<List<Piso>> GetAllAsync()
        {
            return await _context.Pisos.AsNoTracking().ToListAsync();
        }

        public override async Task<bool> Exists(Expression<Func<Piso, bool>> filter)
        {
            return await _context.Pisos.AnyAsync(filter);
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Piso, bool>> filter)
        {
            OperationResult result = new OperationResult(); 
            result.Data = await _context.Pisos.Where(filter).AsNoTracking().ToListAsync();
            return result;
        }

        public override async Task<Piso> GetEntityByIdAsync(int id)
        {
            if(id <= 0)
            {
                return null;
            }

            return await _context.Pisos.FindAsync(id);
        }

        public override async Task<OperationResult> SaveEntityAsync(Piso entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (string.IsNullOrWhiteSpace(entity.Descripcion))
                {
                    throw new ArgumentNullException("El piso debe tener descripcion");
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

        public override async Task<OperationResult> UpdateEntityAsync(Piso entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (string.IsNullOrWhiteSpace(entity.Descripcion))
                {
                    throw new ArgumentNullException("El piso debe tener descripcion");
                }

                _context.Pisos.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorPisoRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
