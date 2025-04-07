using FrancoHotel.WebApi.Models.HabitacionModels;
using System.Net.Http.Json;
using FrancoHotel.WebApi.Models.PisoModels;
using FrancoHotel.WebApi.Repositories.Interfaces;
using FrancoHotel.WebApi.Models;

namespace FrancoHotel.WebApi.Repositories.Classes
{
    public class PisoRepository : IPisoRepository
    {
        private readonly HttpClient _httpClient;

        public PisoRepository(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ApiClient");
        }
        public async Task CreateEntityAsync(PostPisoModel model)
        {
            var response = await _httpClient.PostAsJsonAsync<PostPisoModel>("Piso/SavePiso", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetPisoModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Piso/GetPisos");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetPisoModel>>>();
            return result!.Data;
        }

        public async Task<RemovePisoModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Piso/GetPisoById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemovePisoModel>>();
            return result!.Data;
        }

        public async Task<GetPisoModel> GetByIdUpdateAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Piso/GetPisoById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetPisoModel>>();
            return result!.Data;
        }

        public async Task RemoveEntityAsync(RemovePisoModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<RemovePisoModel>("Piso/RemovePiso", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetPisoModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<GetPisoModel>("Piso/UpdatePiso", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
