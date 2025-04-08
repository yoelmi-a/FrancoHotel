using FrancoHotel.WebApi.Models.UsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using FrancoHotel.WebApi.Service.Interfaces;

namespace FrancoHotel.WebApi.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetUsuarioModel>> GetAllAsync()
        {
            var usuarios = await _repository.GetAllAsync();
            if (usuarios == null || usuarios.Count == 0)
            {
                throw new Exception("No se obtuvo el usuario");
            }
            return usuarios;
        }

        public async Task<GetUsuarioModel> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(id));
            }

            var usuarios = await _repository.GetByIdAsync(id);
            if (usuarios == null)
            {
                throw new Exception("No se obtuvo el usuario");
            }
            return usuarios;
        }

        public async Task<RemoveUsuarioModel> GetByIdRemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(id));
            }

            var usuarios = await _repository.GetByIdRemoveAsync(id);
            if (usuarios == null)
            {
                throw new Exception("No se obtuvo el usuario");
            }
            return usuarios;
        }

        public async Task CreateEntityAsync(PostUsuarioModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(model.Clave))
            {
                throw new ArgumentException("La clave no puede ser nula o vacia", nameof(model.Clave));
            }
            await _repository.CreateEntityAsync(model);
        }

        public async Task UpdateEntityAsync(GetUsuarioModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }

            if (model.IdUsuario <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(model.IdUsuario));
            }
            await _repository.UpdateEntityAsync(model);
        }

        public async Task RemoveEntityAsync(RemoveUsuarioModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }
            if (model.IdUsuario <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(model.IdUsuario));
            }
            await _repository.RemoveEntityAsync(model);
        }
    }
}
