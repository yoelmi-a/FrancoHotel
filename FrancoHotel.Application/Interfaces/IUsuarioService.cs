using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IUsuarioService : IBaseService<SaveUsuarioDtos, UpdateUsuarioDtos, RemoveUsuarioDtos>
    {
        Task<OperationResult> GetUsuarioByIdRolUsuario(int idRolUsuario);
        Task<List<OperationResult>> GetUsuariosByEstado(bool estado);
    }
}