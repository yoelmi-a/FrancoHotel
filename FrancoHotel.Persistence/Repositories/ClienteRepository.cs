using System.Linq.Expressions;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Base;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class ClienteRepository : BaseRepository<Cliente, int>, IClienteRepository
{
    private readonly HotelContext _context;
    private readonly ILogger<ClienteRepository> _logger;
    private readonly IConfiguration _configuration;

    public ClienteRepository(HotelContext context,
                             ILogger<ClienteRepository> logger,
                             IConfiguration configuration) : base(context)
    {
        _context = context;
        _logger = logger;
        _configuration = configuration;
    }

    public override async Task<bool> Exists(Expression<Func<Cliente, bool>> filter)
    {
        return await _context.Cliente.AnyAsync(filter).ConfigureAwait(false);
    }

    public override async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Cliente
            .AsNoTracking()
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public override async Task<OperationResult> GetAllAsync(Expression<Func<Cliente, bool>> filter)
    {
        var clientes = await _context.Cliente
            .Where(c => c.Borrado == false)
            .AsNoTracking()
            .Where(filter)
            .ToListAsync()
            .ConfigureAwait(false);

        return new OperationResult
        {
            Success = true,
            Data = clientes
        };
    }

    public override async Task<Cliente?> GetEntityByIdAsync(int id)
    {
        if (RepoValidation.ValidarID(id))
        {
            return null;
        }
        return await _context.Cliente.FindAsync(id).ConfigureAwait(false);
    }

    public async Task<Cliente?> GetClienteByDocumento(string documento)
    {
        return await _context.Cliente
                             .AsNoTracking()
                             .Where(c => c.Documento == documento)
                             .FirstOrDefaultAsync()
                             .ConfigureAwait(false);
    }

    public async Task<List<Cliente>> GetClientesByEstado(bool estado)
    {
        return await _context.Cliente
                             .AsNoTracking()
                             .Where(c => c.EstadoYFecha.Estado == estado)
                             .ToListAsync();
    }

    public override async Task<OperationResult> SaveEntityAsync(Cliente entity)
    {
        OperationResult result = new OperationResult();

        if (!RepoValidation.ValidarCliente(entity))
        {
            result.Message = this._configuration["ErrorClienteRepository:InvalidData"]!;
            result.Success = false;
            return result;
        }
        try
        {
            _context.Cliente.Add(entity);
            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            result.Message = this._configuration["ErrorClienteRepository:SaveEntityAsync"]!;
            result.Success = false;
            this._logger.LogError(result.Message, ex.ToString());
        }
        return result;
    }

    public override async Task<OperationResult> UpdateEntityAsync(Cliente entity)
    {
        OperationResult result = new OperationResult();

        if (!RepoValidation.ValidarCliente(entity) || !RepoValidation.ValidarID(entity.Id) || !RepoValidation.ValidarID(entity.UsuarioMod) || !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
        {
            result.Message = _configuration["ErrorClienteRepository:InvalidData"]!;
            result.Success = false;
            return result;
        }
        try
        {
            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            result.Message = this._configuration["ErrorClienteRepository:UpdateEntityAsync"]!;
            result.Success = false;
            this._logger.LogError(result.Message, ex.ToString());
        }
        return result;
    }

    public async Task<OperationResult> UpdateTipoDocumento(Cliente entity)
    {
        OperationResult result = new OperationResult();

        if (!RepoValidation.ValidarCliente(entity) ||
            !RepoValidation.ValidarID(entity.UsuarioMod) ||
            !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
        {
            result.Message = _configuration["ErrorClienteRepository:InvalidData"]!;
            result.Success = false;
            return result;
        }

        try
        {
            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            result.Success = true;
        }
        catch (Exception ex)
        {
            result.Message = _configuration["ErrorClienteRepository:UpdateEntityAsync"]!;
            result.Success = false;
            _logger.LogError(result.Message, ex);
        }
        return result;
    }

    public async Task<OperationResult> UpdateEstado(Cliente entity, bool nuevoEstado)
    {
        OperationResult result = new OperationResult();

        if (!RepoValidation.ValidarCliente(entity) ||
            !RepoValidation.ValidarID(entity.UsuarioMod) ||
            !RepoValidation.ValidarEntidad(entity.FechaModificacion!))
        {
            result.Message = _configuration["ErrorClienteRepository:InvalidData"]!;
            result.Success = false;
            return result;
        }
        try
        {
            entity.EstadoYFecha.Estado = nuevoEstado;
            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result.Message = _configuration["ErrorClienteRepository:UpdateEntityAsync"]!;
            result.Success = false;
            _logger.LogError(result.Message, ex.ToString());
        }

        return result;
    }

    public override async Task<OperationResult> RemoveEntityAsync(Cliente entity)
    {
        OperationResult result = new OperationResult();

        if (!RepoValidation.ValidarCliente(entity) ||
            !RepoValidation.ValidarID(entity.Id) ||
                !RepoValidation.ValidarID(entity.UsuarioMod) ||
                !RepoValidation.ValidarEntidad(entity.FechaModificacion!) ||
                !RepoValidation.ValidarID(entity.BorradoPorU) ||
                !RepoValidation.ValidarEntidad(entity.Borrado!))
        {
            result.Message = _configuration["ErrorClienteRepository:InvalidData"]!;
            result.Success = false;
            return result;
        }
        try
        {
            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result.Message = _configuration["ErrorClienteRepository:RemoveEntity"]!;
            result.Success = false;
            _logger.LogError(result.Message, ex.ToString());
        }
        return result;
    }
}