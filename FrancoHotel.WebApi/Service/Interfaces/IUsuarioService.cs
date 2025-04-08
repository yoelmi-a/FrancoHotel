using FrancoHotel.WebApi.Models.UsuarioModels;
using FrancoHotel.WebApi.Service.Interfaces.Base;

namespace FrancoHotel.WebApi.Service.Interfaces
{
    public interface IUsuarioService : IBaseService<GetUsuarioModel, PostUsuarioModel, RemoveUsuarioModel>
    {
    }
}
