using FrancoHotel.WebApi.Models.CategoriaModels;
using FrancoHotel.WebApi.Service.Interfaces.Base;
namespace FrancoHotel.WebApi.Service.Interfaces
{
    public interface ICategoriaService : IBaseService<GetCategoriaModel, PostCategoriaModel, RemoveCategoriaModel>
    {
    }
}
