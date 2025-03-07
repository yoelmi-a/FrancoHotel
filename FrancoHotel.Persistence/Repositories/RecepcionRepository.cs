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
            
            if (RepoValidation.ValidarID(entity.IdCliente))
            {
                result.Message = _configuration["ErrorRecepcionRepository:SaveEntityAsync"]!;
            }
            if (RepoValidation.ValidarID(entity.IdHabitacion))
            {
                result.Message = _configuration["ErrorRecepcionRepository:SaveEntityAsync"]!;
            }
            try
            {
                await _context.Recepcion.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                result.Message = _configuration["ErrorRecepcionRepository:UpdateEntityAsync"]!;
                result.Success = false;
                this._logger.LogError(result.Message, ToString());
            }


            return result;
        }

       

        public override async Task<OperationResult> UpdateEntityAsync(Recepcion entity)
        {
            OperationResult result = new OperationResult();

            if (RepoValidation.ValidarID(entity.Id) == null)
            {
                result.Message = _configuration["ErrorRecepcionRepository:UpdateEntityAsync"]!;
            }
            else if(RepoValidation.ValidarID(entity.IdCliente) == null)
            {
                result.Message = _configuration["ErrorRecepcionRepository:UpdateEntityAsync"]!;
            }
            else if(RepoValidation.ValidarID(entity.IdHabitacion) == null)
            {
                result.Message = _configuration["ErrorRecepcionRepository:UpdateEntityAsync"]!;
            }
            try
            {
                _context.Recepcion.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorRecepcionRepository:UpdateEntityAsync"]!;
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Recepcion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Recepcion.Where(filter)
                                                           .AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result;
        }

        public override async Task<List<Recepcion>> GetAllAsync()
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Recepcion.AsNoTracking()
                                                           .ToListAsync()
                                                           .ConfigureAwait(false);
            return result.Data;
        }
        public override async Task<bool> Exists(Expression<Func<Recepcion, bool>> filter)
        {
            return await _context.Recepcion.AnyAsync(filter).ConfigureAwait(false);
        }
        public override async Task<Recepcion?> GetEntityByIdAsync(int id)
        {
            OperationResult result = new OperationResult();
            if (RepoValidation.ValidarID(id) == null)
            {
                return null;
            }
                return await _context.Recepcion.FindAsync(id);
        }

        public override async Task<OperationResult> RemoveEntityAsync(int id, int idUsuarioMod)
        {
            OperationResult result = new OperationResult();
            Recepcion? entity = await GetEntityByIdAsync(id);

            if (!RepoValidation.ValidarID(id) ||
                !RepoValidation.ValidarID(idUsuarioMod))
            {
                result.Message = _configuration["ErrorRecepcionRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            else if (!RepoValidation.ValidarEntidad(entity!))
            {
                result.Message = _configuration["ErrorRecepcionRepository:UserNotFound"]!;
                result.Success = false;
                return result;
            }
            try
            {
                entity!.Borrado = true;
                entity.BorradoPorU = idUsuarioMod;
                entity.UsuarioMod = idUsuarioMod;
                entity.FechaModificacion = DateTime.Now;
                await UpdateEntityAsync(entity);
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorRecepcionRepository:RemoveEntity"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
