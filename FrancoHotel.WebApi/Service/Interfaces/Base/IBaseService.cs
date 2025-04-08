using FrancoHotel.WebApi.Models.CategoriaModels;

namespace FrancoHotel.WebApi.Service.Interfaces.Base
{
    public interface IBaseService<GetModelService, PostModelService, RemoveModelService> where GetModelService : class
    {
        Task<List<GetModelService>> GetAllAsync();
        Task<GetModelService> GetByIdAsync(int id);
        Task<RemoveModelService> GetByIdRemoveAsync(int id);
        Task CreateEntityAsync(PostModelService model);
        Task UpdateEntityAsync(GetModelService model);
        Task RemoveEntityAsync(RemoveModelService model);
    }
}