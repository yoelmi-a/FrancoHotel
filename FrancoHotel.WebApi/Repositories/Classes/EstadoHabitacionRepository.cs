using System.Net.Http.Json;
using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.EstadoHabitacionModels;
using FrancoHotel.WebApi.Models.PisoModels;
using FrancoHotel.WebApi.Repositories.Interfaces;

namespace FrancoHotel.WebApi.Repositories.Classes
{
    public class EstadoHabitacionRepository : IEstadoHabitacionRepository
    {
        private readonly HttpClient _httpClient;

        public EstadoHabitacionRepository(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ApiClient");
        }
        public async Task CreateEntityAsync(PostEstadoHabitacionModel model)
        {
            var response = await _httpClient.PostAsJsonAsync<PostEstadoHabitacionModel>("EstadoHabitacion/SaveEstadoHabitacion", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetEstadoHabitacionModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("EstadoHabitacion/GetEstadoHabitacion");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetEstadoHabitacionModel>>>();
            return result!.Data;
        }

        public async Task<RemoveEstadoHabitacionModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpClient.GetAsync($"EstadoHabitacion/GetEstadoHabitacionById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveEstadoHabitacionModel>>();
            return result!.Data;
        }

        public async Task<GetEstadoHabitacionModel> GetByIdUpdateAsync(int id)
        {
            var response = await _httpClient.GetAsync($"EstadoHabitacion/GetEstadoHabitacionById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetEstadoHabitacionModel>>();
            return result!.Data;
        }

        public async Task RemoveEntityAsync(RemoveEstadoHabitacionModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<RemoveEstadoHabitacionModel>("EstadoHabitacion/RemoveEstadoHabitacion", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetEstadoHabitacionModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<GetEstadoHabitacionModel>("EstadoHabitacion/UpdateEstadoHabitacion", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
