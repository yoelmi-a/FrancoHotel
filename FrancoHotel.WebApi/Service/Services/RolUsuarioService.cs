using FrancoHotel.WebApi.Models.RolUsuarioModels;
using FrancoHotel.WebApi.Repository.Interfaces;
using FrancoHotel.WebApi.Service.Interfaces;

namespace FrancoHotel.WebApi.Service.Services
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IRolUsuarioRepository _repository;
        public RolUsuarioService(IRolUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetRolUsuarioModel>> GetAllAsync()
        {
            var rol = await _repository.GetAllAsync();
            if (rol == null || rol.Count == 0)
            {
                throw new Exception("No se obtuvo el rol");
            }
            return rol;
        }

        public async Task<GetRolUsuarioModel> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(id));
            }

            var rol = await _repository.GetByIdAsync(id);
            if (rol == null)
            {
                throw new Exception("No se obtuvo el rol");
            }
            return rol;
        }

        public async Task<RemoveRolUsuarioModel> GetByIdRemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(id));
            }

            var rol = await _repository.GetByIdRemoveAsync(id);
            if (rol == null)
            {
                throw new Exception("No se obtuvo el rol");
            }
            return rol;
        }

        public async Task CreateEntityAsync(PostRolUsuarioModel model)
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

        public async Task UpdateEntityAsync(GetRolUsuarioModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }

            if (model.IdRolUsuario <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(model.IdRolUsuario));
            }
            await _repository.UpdateEntityAsync(model);
        }
        public async Task RemoveEntityAsync(RemoveRolUsuarioModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "El modelo no puede ser nulo");
            }
            if (model.IdRolUsuario <= 0)
            {
                throw new ArgumentException("El id debe de ser mayor a 0", nameof(model.IdRolUsuario));
            }
            await _repository.RemoveEntityAsync(model);
        }
    }
}
