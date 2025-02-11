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
        ArgumentException.ThrowIfNullOrEmpty(documento, nameof(documento));

        var cliente = await _context.Clientes
            .FirstOrDefaultAsync(c => c.Documento == documento)
            .ConfigureAwait(false);

        if (cliente == null)
        {
            _logger.LogWarning("No se encontró ningún cliente con el documento {Documento}.", documento);
        }

        return cliente;
    }

    public async Task<List<Cliente>> GetClientesByEstado(bool estado)
    {
        var clientes = await _context.Clientes
            .Where(c => c.EstadoYFecha != null && c.EstadoYFecha.Estado == estado)
            .ToListAsync()
            .ConfigureAwait(false);

        if (!clientes.Any())
        {
            _logger.LogWarning("No se encontraron clientes con el estado {Estado}.", estado);
        }

        return clientes;
    }

    public async Task<OperationResult> UpdateTipoDocumento(int idCliente, string nuevoTipoDocumento)
    {
        OperationResult result = new OperationResult();
        try
        {
            var cliente = await GetClienteByIdAsync(idCliente);

            ArgumentException.ThrowIfNullOrEmpty(nuevoTipoDocumento, nameof(nuevoTipoDocumento));

            if (cliente.TipoDocumento == nuevoTipoDocumento)
            {
                result.Success = false;
                result.Message = "El nuevo tipo de documento es el mismo que el actual.";
                return result;
            }

            cliente.TipoDocumento = nuevoTipoDocumento;
            await _context.SaveChangesAsync();

            result.Success = true;
            result.Message = "Tipo de documento actualizado correctamente.";
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrió un error actualizando el tipo de documento.";
            _logger.LogError(ex, result.Message);
        }
        return result;
    }

    public async Task<OperationResult> UpdateEstado(int idCliente, bool nuevoEstado)
    {
        OperationResult result = new OperationResult();
        try
        {
            var cliente = await GetClienteByIdAsync(idCliente);

            if (cliente.EstadoYFecha.Estado == nuevoEstado)
            {
                result.Success = false;
                result.Message = "El nuevo estado es el mismo que el actual.";
                return result;
            }

            cliente.EstadoYFecha.Estado = nuevoEstado;
            await _context.SaveChangesAsync();

            result.Success = true;
            result.Message = "Estado actualizado correctamente.";
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrió un error actualizando el estado del cliente.";
            _logger.LogError(ex, result.Message);
        }
        return result;
    }

    private async Task<Cliente> GetClienteByIdAsync(int idCliente)
    {
        var cliente = await _context.Clientes.FindAsync(idCliente);
        if (cliente == null)
        {
            throw new KeyNotFoundException($"Cliente con ID {idCliente} no encontrado.");
        }
        return cliente;
    }
}