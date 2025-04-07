using FrancoHotel.WebApi.Models.PisoModels;
using System.Net.Http.Json;
using FrancoHotel.WebApi.Models.ServiciosModels;
using FrancoHotel.WebApi.Repositories.Interfaces;
using FrancoHotel.WebApi.Models;

namespace FrancoHotel.WebApi.Repositories.Classes
{
    public class ServiciosRepository : IServiciosRepository
    {
        private readonly HttpClient _httpClient;

        public ServiciosRepository(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ApiClient");
        }
        public async Task CreateEntityAsync(PostServiciosModel model)
        {
            var response = await _httpClient.PostAsJsonAsync<PostServiciosModel>("Servicio/SaveServicio", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetServiciosModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Servicio/GetServicios");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetServiciosModel>>>();
            return result!.Data;
        }

        public async Task<RemoveServiciosModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Servicio/GetServicioById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveServiciosModel>>();
            return result!.Data;
        }

        public async Task<GetServiciosModel> GetByIdUpdateAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Servicio/GetServicioById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetServiciosModel>>();
            return result!.Data;
        }

        public async Task RemoveEntityAsync(RemoveServiciosModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<RemoveServiciosModel>("Servicio/RemoveServicio", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetServiciosModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<GetServiciosModel>("Servicio/UpdateServicio", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
