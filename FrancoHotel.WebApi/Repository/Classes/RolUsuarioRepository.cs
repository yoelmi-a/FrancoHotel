using FrancoHotel.WebApi.Models;
using FrancoHotel.WebApi.Models.RolUsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces;

namespace FrancoHotel.WebApi.Repository.Classes
{
    public class RolUsuarioRepository : IRolUsuarioRepository
    {
        private readonly HttpClient _httpCliente;
        public RolUsuarioRepository(IHttpClientFactory clientFactory)
        {
            _httpCliente = clientFactory.CreateClient("ApiClient");
        }
        public async Task<List<GetRolUsuarioModel>> GetAllAsync()
        {
            var response = await _httpCliente.GetAsync("RolUsuario/GetRolUsuarios");
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadFromJsonAsync<OperationResultModel<List<GetRolUsuarioModel>>>();
            return result.Result!.Data;
        }

        public async Task<GetRolUsuarioModel> GetByIdAsync(int id)
        {
            var response = await _httpCliente.GetAsync($"RolUsuario/GetRolUsuarioById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<GetRolUsuarioModel>>();
            return result!.Data;
        }

        public async Task<RemoveRolUsuarioModel> GetByIdRemoveAsync(int id)
        {
            var response = await _httpCliente.GetAsync($"RolUsuario/GetRolUsuarioById?id={id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OperationResultModel<RemoveRolUsuarioModel>>();
            return result!.Data;
        }
        public async Task CreateEntityAsync(PostRolUsuarioModel model)
        {
            var response = await _httpCliente.PostAsJsonAsync("RolUsuario/SaveRolUsuario", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEntityAsync(GetRolUsuarioModel model)
        {
            var response = await _httpCliente.PutAsJsonAsync("RolUsuario/UpdateRolUsuario", model);
            response.EnsureSuccessStatusCode();
        }
        public async Task RemoveEntityAsync(RemoveRolUsuarioModel model)
        {
            var response = await _httpCliente.PutAsJsonAsync("RolUsuario/RemoveRolUsuario", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
