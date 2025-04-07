using FrancoHotel.WedApi.Interfaces;
using FrancoHotel.WedApi.Models;
using FrancoHotel.WedApi.Models.RecepcionModels;
using FrancoHotel.WedApi.Models.TarifasModels;

namespace FrancoHotel.WedApi.Clases
{
    public class RecepcionRepository : IRecepcionRepository
    {
        private readonly HttpClient _httpClient;

        public RecepcionRepository(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ApiClient");
        }

        public async Task CreateEntityAsync(PostRecepcionModel model)
        {
            var response = await _httpClient.PostAsJsonAsync<PostRecepcionModel>("Recepcion/SaveRecepcion", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetRecepcionModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Recepcion/GetRecepcion");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetRecepcionModel>>>();
            return result!.Data;
        }

        public async Task<RemoveRecepcionModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Recepcion/GetRecepcionById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveRecepcionModel>>();
            return result!.Data;
        }

        public async Task<GetRecepcionModel> GetByIdUpdateAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Recepcion/GetRecepcionById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetRecepcionModel>>();
            return result!.Data;
        }

        public async Task RemoveEntityAsync(RemoveRecepcionModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<RemoveRecepcionModel>("Recepcion/RemoveRecepcion", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetRecepcionModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<GetRecepcionModel>("Recepcion/UpdateRecepcion", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
