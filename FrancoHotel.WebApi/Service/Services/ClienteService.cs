using FrancoHotel.WebApi.Models.CategoriaModels;
using FrancoHotel.WebApi.Models.ClienteModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using FrancoHotel.WebApi.Service.Interfaces;

namespace FrancoHotel.WebApi.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetClienteModel>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsync();
            if (clientes == null || clientes.Count == 0)
            {
                throw new Exception("No se obtuvo el cliente");
            }
            return clientes;
        }

        public async Task<GetClienteModel> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(id));
            }

            var categorias = await _repository.GetByIdAsync(id);
            if (categorias == null)
            {
                throw new Exception("No se obtuvo el cliente");
            }
            return categorias;
        }

        public async Task<RemoveClienteModel> GetByIdRemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(id));
            }

            var categorias = await _repository.GetByIdRemoveAsync(id);
            if (categorias == null)
            {
                throw new Exception("No se obtuvo el cliente");
            }
            return categorias;
        }

        public async Task CreateEntityAsync(PostClienteModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(model.Documento))
            {
                throw new ArgumentException("El documento no puede ser nula o vacia", nameof(model.Documento));
            }
            await _repository.CreateEntityAsync(model);
        }

        public async Task UpdateEntityAsync(GetClienteModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }

            if (model.IdCliente <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(model.IdCliente));
            }
            await _repository.UpdateEntityAsync(model);
        }

        public async Task RemoveEntityAsync(RemoveClienteModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }
            if (model.IdCliente <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(model.IdCliente));
            }
            await _repository.RemoveEntityAsync(model);
        }
    }
}
