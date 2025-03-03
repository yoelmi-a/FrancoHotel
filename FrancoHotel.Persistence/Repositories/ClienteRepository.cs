using System.Linq.Expressions;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Base;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class ClienteRepository : BaseRepository<Cliente, int>, IClienteRepository
{
    private readonly HotelContext _context;
    private readonly ILogger<ClienteRepository> _logger;
    private readonly IConfiguration _configuration;
    private static bool? nuevoEstado;

    public ClienteRepository(HotelContext context,
                             ILogger<ClienteRepository> logger,
                             IConfiguration configuration) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    public async Task<Cliente?> GetClienteByDocumento(string documento)
    {
        if (string.IsNullOrWhiteSpace(documento) || documento.Contains(" "))
        {
            _logger.LogWarning("El documento proporcionado es inválido.");
            return new List<Cliente>();
        }

        return await _context.Cliente
            .AsNoTracking()
            .Where(c => c.Documento != null && c.Documento == documento)
            .ToListAsync()
            .ConfigureAwait(false);
    }


    public async Task<List<Cliente>> GetClientesByEstado(bool estado)
    {
        return await _context.Cliente
            .AsNoTracking()
            .Where(c => c.EstadoYFecha != null && c.EstadoYFecha.Estado == estado)
            .ToListAsync()
            .ConfigureAwait(false);
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
        if (id == null || id <= 0)
        {
            _logger.LogWarning("El ID proporcionado no es válido: {Id}", id);
            return null;
        }

        return await _context.Cliente
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id)
            .ConfigureAwait(false);
    }


    public override async Task<OperationResult> SaveEntityAsync(Cliente entity)
    {
        OperationResult result = new OperationResult();
        try
        {
            ValidationOfCliente(entity, result);
            if (!result.Success)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:InvalidData"];
                return result;
            }

            _context.Cliente.Add(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result.Message = this._configuration["ErrorClienteRepository:SaveEntityAsync"];
            result.Success = false;
            this._logger.LogError(result.Message, ex.ToString());
        }

        return result;
    }

    public override async Task<OperationResult> UpdateEntityAsync(Cliente entity)
    {
        OperationResult result = new OperationResult();
        try
        {
            ValidationOfCliente(entity, result);
            if (!result.Success)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:InvalidData"];
                return result;
            }

            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result.Message = this._configuration["ErrorClienteRepository:UpdateEntityAsync"];
            result.Success = false;
            this._logger.LogError(result.Message, ex.ToString());
        }

        return result;
    }

    public async Task<OperationResult> UpdateTipoDocumento(Cliente entity)
    {
        OperationResult result = new OperationResult();
        try
        {
            ValidationOfCliente(entity, result);
            if (!result.Success)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:InvalidData"];
                return result;
            }

            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result.Message = this._configuration["ErrorClienteRepository:UpdateTipoDocumento"];
            result.Success = false;
            this._logger.LogError(result.Message, ex.ToString());
        }

        return result;
    }

    public async Task<OperationResult> UpdateEstado(Cliente entity, bool nuevoEstado)
    {
        OperationResult result = new OperationResult();
        try
        {
            ValidationOfCliente(entity, result);
            if (!result.Success)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:InvalidData"];
                return result;
            }
            entity.EstadoYFecha.Estado = nuevoEstado;
            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result.Message = this._configuration["ErrorClienteRepository:UpdateEstado"];
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
            await _context.Cliente.Where(e => e.Id == id).ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Borrado, true));
        }
        catch (Exception ex)
        {

            result.Message = this._configuration["ErrorClienteRepository:RemoveEntity"]!;
            result.Success = false;
            this._logger.LogError(result.Message, ex.ToString());
        }
        return result;
    }
}