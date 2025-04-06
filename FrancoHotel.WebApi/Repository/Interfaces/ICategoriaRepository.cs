using FrancoHotel.WebApi.Models.CategoriaModels;
using FrancoHotel.WebApi.Repository.Interfaces.Base;

namespace FrancoHotel.WebApi.Repository.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<GetCategoriaModel, PostCategoriaModel, RemoveCategoriaModel>
    {
    }
}