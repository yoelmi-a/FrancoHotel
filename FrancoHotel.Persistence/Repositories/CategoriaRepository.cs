using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Base;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace FrancoHotel.Persistence.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria, int>, ICategoriaRepository
    {
        private readonly HotelContext _context;
        private readonly ILogger<CategoriaRepository> _logger;
        private readonly IConfiguration _configuration;

        public CategoriaRepository(HotelContext context,
                                     ILogger<CategoriaRepository> logger,
                                     IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public override async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.Categoria
                .Where(c => c.Borrado == false)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public override async Task<bool> Exists(Expression<Func<Categoria, bool>> filter)
        {
            return await _context.Categoria.AnyAsync(filter);
        }

        public override async Task<OperationResult> GetAllAsync(Expression<Func<Categoria, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Categoria
                                       .Where(filter)
                                       .Where(p => p.Borrado == false)
                                       .AsNoTracking()
                                       .ToListAsync();
            return result;
        }

        public override async Task<Categoria?> GetEntityByIdAsync(int id)
        {
            if (!RepoValidation.ValidarID(id))
            {
                return null;
            }
            return await _context.Categoria.FindAsync(id).ConfigureAwait(false);
        }

        public override async Task<OperationResult> SaveEntityAsync(Categoria entity)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarCategoria(entity))
            {
                result.Message = _configuration["ErrorCategoriaRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Categoria.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorCategoriaRepository:SaveEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> UpdateEntityAsync(Categoria entity)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarCategoria(entity) ||
                !RepoValidation.ValidarID(entity.Id) ||
                !RepoValidation.ValidarID(entity.UsuarioMod!) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
            {
                result.Message = _configuration["ErrorCategoriaRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Categoria.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorCategoriaRepository:UpdateEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override async Task<OperationResult> RemoveEntityAsync(Categoria entity)
        {
            OperationResult result = new OperationResult();
            if (!RepoValidation.ValidarCategoria(entity) ||
                !RepoValidation.ValidarID(entity.Id) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!) ||
                !RepoValidation.ValidarID(entity.BorradoPorU) ||
                !RepoValidation.ValidarEntidad(entity.Borrado!))
            {
                result.Message = _configuration["ErrorCategoriaRepository:InvalidData"]!;
                result.Success = false;
                return result;
            }
            try
            {
                _context.Categoria.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = _configuration["ErrorCategoriaRepository:RemoveEntityAsync"]!;
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
