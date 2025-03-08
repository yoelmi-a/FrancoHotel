using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.RolUsuariosDtos;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IRolUsuarioService : IBaseService<SaveRolUsuarioDtos, UpdateRolUsuarioDtos, RemoveRolUsuarioDtos>
    {
        Task<OperationResult> GetRolUsuarioByDescripcion(string descripcion);
        Task<List<OperationResult>> GetRolesUsuarioByEstado(bool estado);

        Task<OperationResult> UpdateDescripcion(RolUsuario idRolUsuario, string nuevaDescripcion);
        Task<OperationResult> UpdateEstado(RolUsuario idRolUsuario, bool nuevoEstado);
    }
}