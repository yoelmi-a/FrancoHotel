using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IRolUsuarioRepository : IBaseRepository<RolUsuario, int>
    {
        Task<List<RolUsuario>> GetRolUsuarioByDescripcion(string descripcion)
        Task<List<RolUsuario>> GetRolesUsuarioByEstado(bool estado);

        Task<OperationResult> UpdateDescripcion(RolUsuario idRolUsuario, string nuevaDescripcion);
        Task<OperationResult> UpdateEstado(RolUsuario idRolUsuario, bool nuevoEstado);
    }
}