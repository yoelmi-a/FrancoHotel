using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.ClienteModels;
using FrancoHotel.WebApi.Repository.Interfaces;

namespace FrancoHotel.WebApi.Repository.Classes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly HttpClient _httpCliente;
        public ClienteRepository(IHttpClientFactory clientFactory)
        {
            _httpCliente = clientFactory.CreateClient("ApiClient");
        }
        public async Task<List<GetClienteModel>> GetAllAsync()
        {
            var response = await _httpCliente.GetAsync("Cliente/GetClientes");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetClienteModel>>>();
            return result!.Data;
        }

        public async Task<GetClienteModel> GetByIdAsync(int id)
        {
            var response = await _httpCliente.GetAsync($"Cliente/GetClienteById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetClienteModel>>();
            return result!.Data;
        }

        public async Task<RemoveClienteModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpCliente.GetAsync($"Cliente/GetClienteById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveClienteModel>>();
            return result!.Data;
        }
        public async Task CreateEntityAsync(PostClienteModel model)
        {
            var response = await _httpCliente.PostAsJsonAsync("Cliente/SaveCliente", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetClienteModel model)
        {
            var response = await _httpCliente.PutAsJsonAsync("Cliente/UpdateCliente", model);
            response.EnsureSuccessStatusCode();
        }
        public Task RemoveEntityAsync(RemoveClienteModel model)
        {
            var response = _httpCliente.PutAsJsonAsync("Cliente/RemoveCliente", model);
            response.Result.EnsureSuccessStatusCode();
            return Task.CompletedTask;
        }
    }
}
