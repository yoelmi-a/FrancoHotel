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
    public class ServiciosRepository : BaseRepository<Servicios, int>, IServiciosRepository
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

        public override async Task<bool> Exists(Expression<Func<Servicios, bool>> filter)
        {
            return await _context.Servicios.AnyAsync();
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

        public override async Task<Servicios?> GetEntityByIdAsync(int id)
        {
            if(!RepoValidation.ValidarID(id))
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
                result.Message = this._configuration["ErrorServiciosRepository:SaveEntityAsync"]!;
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
                result.Message = this._configuration["ErrorServiciosRepository:UpdateEntityAsync"]!;
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> RemoveEntityAsync(int id, int idUsuarioMod, DateTime fechaMod)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarID(id) ||
                !RepoValidation.ValidarID(idUsuarioMod) ||
                !RepoValidation.ValidarEntidad(fechaMod))
            {
                result.Message = _configuration["ErrorServiciosRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                await _context.Servicios
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(e => e.Borrado, true)
                .SetProperty(e => e.UsuarioMod, idUsuarioMod)
                .SetProperty(e => e.FechaModificacion, fechaMod)
                );
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["ErrorServiciosRepository:RemoveEntity"]!;
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
