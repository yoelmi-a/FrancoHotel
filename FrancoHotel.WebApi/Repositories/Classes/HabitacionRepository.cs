using System.Collections.Generic;
using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.HabitacionModels;
using FrancoHotel.WebApi.Repositories.Interfaces;

namespace FrancoHotel.WebApi.Repositories.Classes
{
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly HttpClient _httpClient;

        public HabitacionRepository(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ApiClient");
        }
        public async Task CreateEntityAsync(PostHabitacionModel model)
        {
            var response = await _httpClient.PostAsJsonAsync<PostHabitacionModel>("Habitacion/SaveHabitacion", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<GetHabitacionModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Habitacion/GetHabitacion");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetHabitacionModel>>>();
            return result!.Data;
        }

        public async Task<RemoveHabitacionModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Habitacion/GetHabitacionById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveHabitacionModel>>();
            return result!.Data;
        }

        public async Task<GetHabitacionModel> GetByIdUpdateAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Habitacion/GetHabitacionById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetHabitacionModel>>();
            return result!.Data;
        }

        public async Task RemoveEntityAsync(RemoveHabitacionModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<RemoveHabitacionModel>("Habitacion/RemoveHabitacion", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetHabitacionModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<GetHabitacionModel>("Habitacion/UpdateHabitacion", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
