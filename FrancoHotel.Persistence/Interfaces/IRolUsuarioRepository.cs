using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IRolUsuarioRepository : IBaseRepository<RolUsuario, int>
    {
        Task<RolUsuario> GetRolUsuarioByDescripcion(string descripcion);
        Task<List<RolUsuario>> GetRolesUsuarioByEstado(bool estado);

        Task<OperationResult> UpdateDescripcion(int idRolUsuario, string nuevaDescripcion);
        Task<OperationResult> UpdateEstado(int idRolUsuario, bool nuevoEstado);
    }
}