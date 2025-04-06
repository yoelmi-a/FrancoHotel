using FrancoHotel.WebApi.Models.PisoModels;

namespace FrancoHotel.WebApi.Repositories.Interfaces
{
    public interface IPisoRepository : IBaseRepository<GetPisoModel, PostPisoModel, RemovePisoModel>
    {
    }
}
