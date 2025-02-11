using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente, int>
    {
        Task<Cliente> GetClienteByDocumento(string documento);
        Task<List<Cliente>> GetClientesByEstado(bool estado);

        Task<OperationResult> UpdateTipoDocumento(int idCliente, string nuevoTipoDocumento);
        Task<OperationResult> UpdateEstado(int idCliente, bool nuevoEstado);
    }
}
