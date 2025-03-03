
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface ITarifasRepository : IBaseRepository<Tarifas, int>
    {
        Task<OperationResult> AddTarifaByCategoria(string IdCategoria, double Precio);  

       
        Task<OperationResult> UpdateTarifasByFechas(DateTime FechaInicio, DateTime FechaFinal, double porcentajeCambio);

        Task<OperationResult> TotalTarifa(int IdCategoria, int Days, int? ServiciosAdicionales);
    }
}
