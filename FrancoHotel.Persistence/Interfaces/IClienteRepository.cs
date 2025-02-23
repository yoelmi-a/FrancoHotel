using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente, int>
    {
        Task<List<Cliente>> GetClienteByDocumento(string documento);
        Task<List<Cliente>> GetClientesByEstado(bool estado);

        Task<OperationResult> UpdateTipoDocumento(Cliente entity);
        Task<OperationResult> UpdateEstado(Cliente entity, bool nuevoEstado);
    }
}
