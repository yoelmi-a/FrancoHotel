using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IClienteService : IBaseService<SaveUsuarioDtos, UpdateUsuario, RemoveUsuarioDtos>
    {
        Task<OperationResult> GetClienteByDocumento(string documento);
        Task<List<OperationResult>> GetClientesByEstado(bool estado);

        Task<OperationResult> UpdateTipoDocumento(Cliente entity);
        Task<OperationResult> UpdateEstado(Cliente entity, bool nuevoEstado);
    }
}
