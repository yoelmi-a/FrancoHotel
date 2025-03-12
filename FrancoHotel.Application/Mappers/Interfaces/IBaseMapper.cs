namespace FrancoHotel.Application.Mappers.Interfaces
{
    public interface IBaseMapper<TDtoSave, TDtoUpdate, TDtoRemove, TEntity>
    {
        public TEntity SaveDtoToEntity(TDtoSave dto);
        public TEntity RemoveDtoToEntity(TDtoRemove dto, TEntity entity);
        public TEntity UpdateDtoToEntity(TDtoUpdate dto, TEntity entity);
        public TDtoUpdate EntityToDto(TEntity entity);
        public List<TDtoUpdate> DtoList(List<TEntity> entities);

    }
}