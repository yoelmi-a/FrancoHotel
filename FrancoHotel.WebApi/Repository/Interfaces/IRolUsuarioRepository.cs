using FrancoHotel.WebApi.Models.RolUsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces.Base;

namespace FrancoHotel.WebApi.Repository.Interfaces
{
    public interface IRolUsuarioRepository : IBaseRepository<GetRolUsuarioModel, PostRolUsuarioModel, RemoveRolUsuarioModel>
    {
    }
}