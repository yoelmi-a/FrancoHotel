using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, int>
    {
        Task<Usuario> GetUsuarioByClave(string clave);
        Task<Usuario> GetUsuarioByIdRolUsuario(int idRolUsuario);
        Task<List<Usuario>> GetUsuariosByEstado(bool estado);

        Task<OperationResult> UpdateClave(int idUsuario, string nuevaClave);
        Task<OperationResult> UpdateEstado(int idUsuario, bool nuevoEstado);
    }
}
