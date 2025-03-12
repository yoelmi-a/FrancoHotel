using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IUsuarioMapper : IBaseMapper<SaveUsuarioDtos, UpdateUsuarioDtos, RemoveUsuarioDtos, Usuario>
    {
    }
}
