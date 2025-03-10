using FrancoHotel.Application.Mappers.Interfaces;

namespace FrancoHotel.Application.Mappers.Classes
{
    public abstract class BaseMapper<TDtoSave, TDtoUpdate, TDtoRemove, TENtity> : IBaseMapper<TDtoSave, TDtoUpdate, TDtoRemove, TENtity>
    {
        public abstract TDtoUpdate EntityToDto(TENtity entity);
        public abstract TENtity RemoveDtoToEntity(TDtoRemove dto, TENtity entity);
        public abstract TENtity SaveDtoToEntity(TDtoSave dto);
        public abstract TENtity UpdateDtoToEntity(TDtoUpdate dto, TENtity entity);
    }
}
