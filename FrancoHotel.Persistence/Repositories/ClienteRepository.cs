﻿using System.Linq.Expressions;
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
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.Documento == documento)
            .ConfigureAwait(false);
    }

    public async Task<List<Cliente>> GetClientesByEstado(bool estado)
    {
        return await _context.Clientes
            .Where(c => c.EstadoYFecha != null && c.EstadoYFecha.Estado == estado)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<Cliente> GetClienteByIdAsync(int idCliente)
    {
        return await _context.Clientes.FindAsync(idCliente);
    }

    public override async Task<bool> Exists(Expression<Func<Cliente, bool>> filter)
    {
        return await _context.Clientes.AnyAsync(filter).ConfigureAwait(false);
    }

    public override async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.ToListAsync().ConfigureAwait(false);
    }

    public override async Task<OperationResult> GetAllAsync(Expression<Func<Cliente, bool>> filter)
    {
        var clientes = await _context.Clientes.Where(filter).ToListAsync().ConfigureAwait(false);
        return new OperationResult
        {
            Success = true,
            Data = clientes
        };
    }

    public override async Task<Cliente> GetEntityByIdAsync(int id)
    {
        return await _context.Clientes.FindAsync(id);
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

            await _context.Clientes.AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            result.Success = true;
            result.Message = "Cliente guardado correctamente.";
            _logger.LogInformation(result.Message);
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

            var clienteExistente = await GetEntityByIdAsync(entity.Id);

            if (clienteExistente == null)
            {
                result.Success = false;
                result.Message = "El cliente no existe en la base de datos.";
                return result;
            }

            _context.Entry(clienteExistente).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            result.Success = true;
            result.Message = "Cliente actualizado correctamente.";
            _logger.LogInformation(result.Message);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrió un error al actualizar el cliente.";
            _logger.LogError(ex, result.Message);
        }

        return result;
    }

    public async Task<OperationResult> UpdateTipoDocumento(int idCliente, string nuevoTipoDocumento)
    {
        OperationResult result = new OperationResult();
        try
        {
            if (idCliente <= 0)
            {
                result.Success = false;
                result.Message = "El ID del cliente debe ser mayor que cero.";
                _logger.LogWarning(result.Message);
                return result;
            }

            if (string.IsNullOrWhiteSpace(nuevoTipoDocumento))
            {
                result.Success = false;
                result.Message = "El nuevo tipo de documento no puede estar vacío o ser nulo.";
                _logger.LogWarning(result.Message);
                return result;
            }

            var cliente = await GetClienteByIdAsync(idCliente);

            if (cliente.TipoDocumento == nuevoTipoDocumento)
            {
                result.Success = false;
                result.Message = "El nuevo tipo de documento es el mismo que el actual.";
                _logger.LogWarning(result.Message);
                return result;
            }

            cliente.TipoDocumento = nuevoTipoDocumento;
            await _context.SaveChangesAsync();

            result.Success = true;
            result.Message = "Tipo de documento actualizado correctamente.";
            _logger.LogInformation(result.Message);
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
            if (idCliente <= 0)
            {
                result.Success = false;
                result.Message = "El ID del cliente debe ser mayor que cero.";
                _logger.LogWarning(result.Message);
                return result;
            }

            var cliente = await GetClienteByIdAsync(idCliente);

            if (cliente.EstadoYFecha.Estado == nuevoEstado)
            {
                result.Success = false;
                result.Message = "El nuevo estado es el mismo que el actual.";
                _logger.LogWarning(result.Message);
                return result;
            }

            cliente.EstadoYFecha.Estado = nuevoEstado;
            await _context.SaveChangesAsync();

            result.Success = true;
            result.Message = "Estado actualizado correctamente.";
            _logger.LogInformation(result.Message);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Ocurrió un error actualizando el estado del cliente.";
            _logger.LogError(ex, result.Message);
        }

        return result;
    }
}