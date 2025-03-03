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
            _context = context;
            _logger = logger;
            _configuration = configuration;
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

        public override async Task<Piso?> GetEntityByIdAsync(int id)
        {
            if(!RepoValidation.ValidarID(id))
            {
                return null;
            }

            return await _context.Piso.FindAsync(id);
        }

        public override async Task<OperationResult> SaveEntityAsync(Piso entity)
        {
            OperationResult result = new OperationResult();
            if(!RepoValidation.ValidarPiso(entity))
            {
                result.Message = _configuration["ErrorPisoRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {

                _context.Piso.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorPisoRepository:SaveEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(Piso entity)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarID(entity.Id) || !RepoValidation.ValidarPiso(entity) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) || !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorHabitacionRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Piso.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorPisoRepository:UpdateEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
