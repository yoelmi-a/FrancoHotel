
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Domain.Repository;

namespace FrancoHotel.Persistence.Interfaces
{
    public interface ITarifasRepository : IBaseRepository<Tarifas, int>
    {
        Task<OperationResult> AddTarifaByCategoria(string IdCategoria, double Precio);  //tarifas en base a las categorias de las habitaciones

       
        Task<OperationResult> UpdateTarifasByFechas(DateTime FechaInicio, DateTime FechaFinal, double porcentajeCambio); //el sistema debe permitir configurar las tarifas basadas en temporadas (alta, media, baja)

       
        Task<OperationResult> UpdateTarifa(int IdCategoria, double Precio);     // El sistema debe permitir actualizar tarifas en tiempo real sin afectar reservas existentes

    
        Task<OperationResult> TotalTarifa(int IdCategoria);     // El sistema debe permitir actualizar tarifas en tiempo real sin afectar reservas existentes
    }
}
