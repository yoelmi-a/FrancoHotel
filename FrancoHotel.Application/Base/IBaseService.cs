using FrancoHotel.Domain.Base;

namespace FrancoHotel.Application.Base
{
    public interface IBaseService<TDtoSave, TDtoUpdate, TDtoRemove>
    {
        Task<OperationResult> GetAll();
        Task<OperationResult> GetById(int id);
        Task<OperationResult> Save(TDtoSave dto);
        Task<OperationResult> Update(TDtoUpdate dto);
        Task<OperationResult> Remove(TDtoRemove dto);
    }
}
