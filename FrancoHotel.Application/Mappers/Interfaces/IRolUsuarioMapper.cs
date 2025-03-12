using FrancoHotel.Application.Dtos.RolUsuariosDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IRolUsuarioMapper : IBaseMapper<SaveRolUsuarioDtos, UpdateRolUsuarioDtos, RemoveRolUsuarioDtos, RolUsuario>
    {
    }
}
