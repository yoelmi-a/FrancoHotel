using FrancoHotel.WebApi.Models.ClienteModels;
using FrancoHotel.WebApi.Repository.Interfaces.Base;

namespace FrancoHotel.WebApi.Repository.Interfaces
{
    public interface IClienteRepository : IBaseRepository<GetClienteModel, PostClienteModel, RemoveClienteModel>
    {
    }
}