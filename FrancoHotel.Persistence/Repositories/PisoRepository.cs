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

        public async Task<List<PisoModel>> GetPisoByEstado(bool? estado)
        {
            return await (from piso in _context.Piso
                                   where piso.EstadoYFecha.Estado == estado
                                   select new PisoModel()
                                   {
                                       IdPiso = piso.Id,
                                       Descripcion = piso.Descripcion,
                                       Estado = piso.EstadoYFecha.Estado,
                                       FechaCreacion = piso.EstadoYFecha.FechaCreacion
                                   }).AsNoTracking().ToListAsync();
        }

        public override async Task<List<Piso>> GetAllAsync()
        {
            return await _context.Piso.ToListAsync();
        }

        public override async Task<bool> Exists(Expression<Func<Piso, bool>> filter)
        {
            return await _context.Piso.AnyAsync(filter);
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Piso, bool>> filter)
        {
            OperationResult result = new OperationResult(); 
            result.Data = await _context.Piso.Where(filter).AsNoTracking().ToListAsync();
            return result;
        }

        public override async Task<Piso> GetEntityByIdAsync(int id)
        {
            if(id <= 0)
            {
                return null;
            }

            return await _context.Piso.FindAsync(id);
        }

        public override async Task<OperationResult> SaveEntityAsync(Piso entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                if (string.IsNullOrWhiteSpace(entity.Descripcion) || !entity.EstadoYFecha.Estado.HasValue)
                {
                    throw new ArgumentNullException("El piso debe tener descripcion y estado");
                }

                _context.Piso.Add(entity);
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

                _context.Piso.Update(entity);
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

        public override async Task<OperationResult> RemoveEntityAsync(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                await _context.Piso.Where(e => e.Id == id).ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Borrado, true));
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["ErrorPisoRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
