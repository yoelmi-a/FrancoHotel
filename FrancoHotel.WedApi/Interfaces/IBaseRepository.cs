namespace FrancoHotel.WedApi.Interfaces
{
    public interface IBaseRepository<GetModel, PostModel, RemoveModel> where GetModel : class
    {
        Task<List<GetModel>> GetAllAsync();
        Task<GetModel> GetByIdUpdateAsync(int id);
        Task<RemoveModel> GetByIdRemoveAsync(int id);
        Task CreateEntityAsync(PostModel model);
        Task UpdateEntityAsync(GetModel model);
        Task RemoveEntityAsync(RemoveModel model);
    }
}
