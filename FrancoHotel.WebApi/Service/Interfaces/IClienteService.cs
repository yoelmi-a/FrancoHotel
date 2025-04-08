using FrancoHotel.WebApi.Models.ClienteModels;
using FrancoHotel.WebApi.Service.Interfaces.Base;

namespace FrancoHotel.WebApi.Service.Interfaces
{
    public interface IClienteService : IBaseService<GetClienteModel, PostClienteModel, RemoveClienteModel>
    {
    }
}
