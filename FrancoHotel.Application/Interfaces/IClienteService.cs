using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IClienteService : IBaseService<SaveClienteDtos, UpdateClienteDtos, RemoveClienteDtos>
    {
        Task<OperationResult> GetClienteByDocumento(string documento);
        Task<List<OperationResult>> GetClientesByEstado(bool estado);

        Task<OperationResult> UpdateTipoDocumento(Cliente entity);
        Task<OperationResult> UpdateEstado(Cliente entity, bool nuevoEstado);
    }
}
