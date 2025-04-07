using FrancoHotel.WedApi.Models.TarifasModels;

namespace FrancoHotel.WedApi.Interfaces
{
    public interface ITarifasRepository : IBaseRepository<GetTarifasModel, PostTarifasModel, RemoveTarifasModel>
    {
    }
}
