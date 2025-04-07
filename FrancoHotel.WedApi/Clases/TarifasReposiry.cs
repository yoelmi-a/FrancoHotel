using System.Net.Http.Json;
using FrancoHotel.WedApi.Interfaces;
using FrancoHotel.WedApi.Models;
using FrancoHotel.WedApi.Models.TarifasModels;

namespace FrancoHotel.WedApi.Clases
{
    public class TarifasRepository : ITarifasRepository
    {
        private readonly HttpClient _httpClient;

        public TarifasRepository(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ApiClient");
        }

        public async Task CreateEntityAsync(PostTarifasModel model)
        {
            var response = await _httpClient.PostAsJsonAsync<PostTarifasModel>("Tarifas/SaveTarifas", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetTarifasModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Tarifas/GetTarifas");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetTarifasModel>>>();
            return result!.Data;
        }

        public async Task<RemoveTarifasModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Tarifas/GetTarifasById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveTarifasModel>>();
            return result!.Data;
        }

        public async Task<GetTarifasModel> GetByIdUpdateAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Tarifas/GetTarifasById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetTarifasModel>>();
            return result!.Data;
        }

        public async Task RemoveEntityAsync(RemoveTarifasModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<RemoveTarifasModel>("Tarifas/RemoveTarifas", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetTarifasModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<GetTarifasModel>("Tarifas/UpdateTarifas", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
