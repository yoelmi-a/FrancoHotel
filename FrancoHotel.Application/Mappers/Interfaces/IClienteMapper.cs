using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IClienteMapper : IBaseMapper<SaveClienteDtos, UpdateClienteDtos, RemoveClienteDtos, Cliente>
    {
    }
}
