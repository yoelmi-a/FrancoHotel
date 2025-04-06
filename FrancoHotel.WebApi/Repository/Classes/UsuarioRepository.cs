using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.UsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using System.Net.Http;

namespace FrancoHotel.WebApi.Repository.Classes
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HttpClient _httpCliente;
        public UsuarioRepository(IHttpClientFactory clientFactory)
        {
            _httpCliente = clientFactory.CreateClient("ApiClient");
        }

        public async Task<List<GetUsuarioModel>> GetAllAsync()
        {
            var response = await _httpCliente.GetAsync("Usuario/GetUsuarios");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<List<GetUsuarioModel>>>();
            return result!.Data;
        }

        public async Task<GetUsuarioModel> GetByIdAsync(int id)
        {
            var response = await _httpCliente.GetAsync($"Usuario/GetUsuarioById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetUsuarioModel>>();
            return result!.Data;
        }

        public async Task<RemoveUsuarioModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpCliente.GetAsync($"Usuario/GetUsuarioById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveUsuarioModel>>();
            return result!.Data;
        }

        public async Task CreateEntityAsync(PostUsuarioModel model)
        {
            var response = await _httpCliente.PostAsJsonAsync("Usuario/SaveUsuario", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetUsuarioModel model)
        {
            var response = await _httpCliente.PutAsJsonAsync("Usuario/UpdateUsuario", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveEntityAsync(RemoveUsuarioModel model)
        {
            var response = await _httpCliente.PutAsJsonAsync("Usuario/RemoveUsuario", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
