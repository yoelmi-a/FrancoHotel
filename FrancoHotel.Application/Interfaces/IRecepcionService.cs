
using System.Linq.Expressions;
using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Interfaces
{
    public interface IRecepcionService : IBaseService<SaveRecepcionDto, UpdateRecepcionDto, RemoveRecepcionDto>
    {
        Task<bool> Exists(Expression<Func<Recepcion, bool>> filter);
        Task<OperationResult> GetAllByFilter(Expression<Func<Recepcion, bool>> filter);
        Task<OperationResult> UpdateTarifaByCategoria(string IdCategoria, decimal Precio);

        Task<OperationResult> UpdateTarifasByFechas(DateTime FechaInicio, DateTime FechaFinal, decimal porcentajeCambio);

        Task<OperationResult> TotalTarifa(int IdCategoria, int Days, int? ServiciosAdicionales);
    }
}
    



