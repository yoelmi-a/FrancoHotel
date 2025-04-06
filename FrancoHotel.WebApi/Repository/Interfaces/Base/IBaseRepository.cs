using FrancoHotel.WebApi.Models;

namespace FrancoHotel.WebApi.Repository.Interfaces.Base
{
    public interface IBaseRepository<GetModel, PostModel, RemoveModel> where GetModel : class
    {
        Task<List<GetModel>> GetAllAsync();
        Task<GetModel> GetByIdAsync(int id);
        Task<RemoveModel> GetByIdRemoveAsync(int id);
        Task CreateEntityAsync (PostModel model);
        Task UpdateEntityAsync (GetModel model);
        Task RemoveEntityAsync (RemoveModel model);
    }
}
