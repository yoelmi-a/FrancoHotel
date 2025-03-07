
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface ITarifasRepository : IBaseRepository<Tarifas, int>
    {
        Task<OperationResult> UpdateTarifaByCategoria(string IdCategoria, decimal precio);  

       
        Task<OperationResult> UpdateTarifasByFechas(DateTime FechaInicio, DateTime FechaFinal, double porcentajeCambio);

        Task<OperationResult> TotalTarifa(int IdCategoria, int Days, int? ServiciosAdicionales);
    }
}
