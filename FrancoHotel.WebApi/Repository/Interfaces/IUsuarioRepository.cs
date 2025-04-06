using FrancoHotel.WebApi.Models.UsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces.Base;

namespace FrancoHotel.WebApi.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<GetUsuarioModel, PostUsuarioModel, RemoveUsuarioModel>
    {
    }
}