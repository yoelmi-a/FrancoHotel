using FrancoHotel.WebApi.Models.RolUsuarioModels;
using FrancoHotel.WebApi.Service.Interfaces.Base;

namespace FrancoHotel.WebApi.Service.Interfaces
{
    public interface IRolUsuarioService : IBaseService<GetRolUsuarioModel, PostRolUsuarioModel, RemoveRolUsuarioModel>
    {
    }
}
