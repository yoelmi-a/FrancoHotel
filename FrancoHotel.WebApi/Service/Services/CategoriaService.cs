using FrancoHotel.WebApi.Models.CategoriaModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using FrancoHotel.WebApi.Service.Interfaces;

namespace FrancoHotel.WebApi.Service.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoriaModel>> GetAllAsync()
        {
            var categorias = await _repository.GetAllAsync();
            if (categorias == null || categorias.Count == 0)
            {
                throw new Exception("No se obtuvo la categoria");
            }
            return categorias;
        }

        public async Task<GetCategoriaModel> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(id));
            }

            var categorias = await _repository.GetByIdAsync(id);
            if (categorias == null)
            {
                throw new Exception("No se obtuvo la categoria");
            }
            return categorias;
        }

        public async Task<RemoveCategoriaModel> GetByIdRemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(id));
            }

            var categorias = await _repository.GetByIdRemoveAsync(id);
            if (categorias == null)
            {
                throw new Exception("No se obtuvo la categoria");
            }
            return categorias;
        }

        public async Task CreateEntityAsync(PostCategoriaModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(model.Descripcion))
            {
                throw new ArgumentException("La descripcion no puede ser nula o vacia", nameof(model.Descripcion));
            }
            await _repository.CreateEntityAsync(model);
        }

        public async Task UpdateEntityAsync(GetCategoriaModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }

            if (model.Id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(model.Id));
            }
            await _repository.UpdateEntityAsync(model);
        }

        public async Task RemoveEntityAsync(RemoveCategoriaModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }
            if (model.Id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(model.Id));
            }
            await _repository.RemoveEntityAsync(model);
        }
    }
}
