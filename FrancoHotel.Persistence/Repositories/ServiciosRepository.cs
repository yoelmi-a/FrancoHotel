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
            if(!RepoValidation.ValidarServicio(entity))
            {
                result.Message = _configuration["ErrorServiciosRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Servicios.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorServiciosRepository:SaveEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(Servicios entity)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarID(entity.Id) || !RepoValidation.ValidarServicio(entity) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) || !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorServiciosRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Servicios.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorServiciosRepository:UpdateEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> RemoveEntityAsync(int id, int idUsuarioMod)
        {
            OperationResult result = new OperationResult();
            Servicios? entity = await GetEntityByIdAsync(id);

            if (!RepoValidation.ValidarID(id) ||
                !RepoValidation.ValidarID(idUsuarioMod))
            {
                result.Message = _configuration["ErrorServiciosRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            else if (!RepoValidation.ValidarEntidad(entity!))
            {
                result.Message = _configuration["ErrorServiciosRepository:UserNotFound"]!;
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
                result.Message = _configuration["ErrorServiciosRepository:RemoveEntity"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
