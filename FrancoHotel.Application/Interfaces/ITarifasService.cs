
using System.Linq.Expressions;
using FrancoHotel.Application.Base;
using FrancoHotel.Application.Dtos.TarifasDto;
using FrancoHotel.Application.Dtos.TarifasDtos;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Application.Interfaces
{
    public interface ITarifasService : IBaseService<SaveTarifasDtos, UpdateTarifasDto, RemoveTarifasDto>
    {
        Task<bool> Exists(Expression<Func<Tarifas, bool>> filter);
        Task<OperationResult> GetAllByFilter(Expression<Func<Tarifas, bool>> filter);
        Task<OperationResult> UpdateTarifaByCategoria(string IdCategoria, decimal Precio);

        Task<OperationResult> UpdateTarifasByFechas(DateTime FechaInicio, DateTime FechaFinal, decimal porcentajeCambio);

        Task<OperationResult> TotalTarifa(int IdCategoria, int Days, int? ServiciosAdicionales);
    }
}
