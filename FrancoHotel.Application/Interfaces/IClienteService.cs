using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IClienteService : IBaseService<SaveClienteDtos, UpdateClienteDtos, RemoveClienteDtos>
    {
        Task<OperationResult> GetClienteByDocumento(string documento);
        Task<OperationResult> GetClientesByEstado(bool estado);

        Task<OperationResult> UpdateTipoDocumento(UpdateClienteDtos dto);
        Task<OperationResult> UpdateEstado(UpdateClienteDtos dto, bool nuevoEstado);
    }
}
