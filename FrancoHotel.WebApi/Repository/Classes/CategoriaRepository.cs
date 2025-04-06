using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.CategoriaModels;
using FrancoHotel.WebApi.Repository.Interfaces;

namespace FrancoHotel.WebApi.Repository.Classes
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly HttpClient _httpCliente;
        public CategoriaRepository(IHttpClientFactory clientFactory)
        {
            _httpCliente = clientFactory.CreateClient("ApiClient");
        }
        public async Task<List<GetCategoriaModel>> GetAllAsync()
        {
            var response = await _httpCliente.GetAsync("Categoria/GetCategoria");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetCategoriaModel>>>();
            return result!.Data;
        }

        public async Task<GetCategoriaModel> GetByIdAsync(int id)
        {
            var response = await _httpCliente.GetAsync($"Categoria/GetCategoriaById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetCategoriaModel>>();
            return result!.Data;
        }
        public async Task<RemoveCategoriaModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpCliente.GetAsync($"Categoria/GetCategoriaById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveCategoriaModel>>();
            return result!.Data;
        }

        public async Task CreateEntityAsync(PostCategoriaModel model)
        {
            var response = await _httpCliente.PostAsJsonAsync("Categoria/SaveCategoria", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetCategoriaModel model)
        {
            var response = await _httpCliente.PutAsJsonAsync("Categoria/UpdateCategoria", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveEntityAsync(RemoveCategoriaModel model)
        {
            var response = await _httpCliente.PutAsJsonAsync("Categoria/RemoveCategoria", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
