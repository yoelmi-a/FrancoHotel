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

    public ClienteRepository(HotelContext context,
                             ILogger<ClienteRepository> logger,
                             IConfiguration configuration) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<Cliente> GetClienteByDocumento(string documento)
    {
        if (string.IsNullOrWhiteSpace(documento))
        {
            throw new ArgumentException("El documento no puede estar vacío o ser nulo.", nameof(documento));
        }

        return await _context.Cliente
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Documento == documento)
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

    public override async Task<Cliente> GetEntityByIdAsync(int id)
    {
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
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El cliente no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(entity.TipoDocumento) || entity.TipoDocumento.Length > 15)
            {
                result.Success = false;
                result.Message = "El campo TipoDocumento no puede exceder los 15 caracteres.";
                _logger.LogWarning(result.Message);
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.Documento) || entity.Documento.Length > 15)
            {
                result.Success = false;
                result.Message = "El campo Documento no puede exceder los 15 caracteres.";
                _logger.LogWarning(result.Message);
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.NombreCompleto) || entity.NombreCompleto.Length > 50)
            {
                result.Success = false;
                result.Message = "El campo NombreCompleto no puede exceder los 50 caracteres.";
                _logger.LogWarning(result.Message);
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.Correo) || entity.Correo.Length > 50)
            {
                result.Success = false;
                result.Message = "El campo Correo no puede exceder los 50 caracteres.";
                _logger.LogWarning(result.Message);
                return result;
            }

            _context.Cliente.Add(entity);
            await _context.SaveChangesAsync();

            result.Success = true;
            result.Message = "Cliente guardado correctamente.";
            _logger.LogInformation("Cliente guardado con ID: {IdCliente}", entity.Id);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrió un error al guardar el cliente.";
            _logger.LogError(ex, result.Message);
        }

        return result;
    }

    public override async Task<OperationResult> UpdateEntityAsync(Cliente entity)
    {
        OperationResult result = new OperationResult();
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El cliente no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(entity.TipoDocumento) || entity.TipoDocumento.Length > 15)
            {
                result.Success = false;
                result.Message = "El campo TipoDocumento no puede exceder los 15 caracteres.";
                _logger.LogWarning(result.Message);
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.Documento) || entity.Documento.Length > 15)
            {
                result.Success = false;
                result.Message = "El campo Documento no puede exceder los 15 caracteres.";
                _logger.LogWarning(result.Message);
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.NombreCompleto) || entity.NombreCompleto.Length > 50)
            {
                result.Success = false;
                result.Message = "El campo NombreCompleto no puede exceder los 50 caracteres.";
                _logger.LogWarning(result.Message);
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.Correo) || entity.Correo.Length > 50)
            {
                result.Success = false;
                result.Message = "El campo Correo no puede exceder los 50 caracteres.";
                _logger.LogWarning(result.Message);
                return result;
            }

            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync();

            result.Success = true;
            result.Message = "Cliente guardado correctamente.";
            _logger.LogInformation("Cliente guardado con ID: {IdCliente}", entity.Id);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrió un error al guardar el cliente.";
            _logger.LogError(ex, result.Message);
        }

        return result;
    }

    public async Task<OperationResult> UpdateTipoDocumento(Cliente entity)
    {
        OperationResult result = new OperationResult();
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El cliente no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(entity.TipoDocumento) || entity.TipoDocumento.Length > 15)
            {
                result.Success = false;
                result.Message = "El campo TipoDocumento no puede estar vacío ni exceder los 15 caracteres.";
                _logger.LogWarning(result.Message);
                return result;
            }

            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync();

            result.Success = true;
            result.Message = "TipoDocumento actualizado correctamente.";
            _logger.LogInformation("TipoDocumento actualizado para el cliente con ID: {IdCliente}", entity.Id);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrió un error al actualizar el TipoDocumento.";
            _logger.LogError(ex, result.Message);
        }

        return result;
    }

    public async Task<OperationResult> UpdateEstado(Cliente entity, bool nuevoEstado)
    {
        OperationResult result = new OperationResult();
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "El cliente no puede ser nulo.");
            }

            if (entity.EstadoYFecha.Estado == nuevoEstado)
            {
                result.Success = false;
                result.Message = "El nuevo estado es el mismo que el actual.";
                _logger.LogWarning(result.Message);
                return result;
            }

            entity.EstadoYFecha.Estado = nuevoEstado;
            _context.Cliente.Update(entity);
            await _context.SaveChangesAsync();

            result.Success = true;
            result.Message = "Estado actualizado correctamente.";
            _logger.LogInformation("Estado actualizado para el cliente con ID: {IdCliente}", entity.Id);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrió un error actualizando el estado del cliente.";
            _logger.LogError(ex, result.Message);
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

            result.Message = this._configuration["ErrorClienteRepository:RemoveEntity"];
            result.Success = false;
            this._logger.LogError(result.Message, ex.ToString());
        }
        return result;
    }
}