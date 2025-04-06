using FrancoHotel.WebApi.Models.HabitacionModels;

namespace FrancoHotel.WebApi.Repositories.Interfaces
{
    public interface IHabitacionRepository : IBaseRepository<GetHabitacionModel, PostHabitacionModel, RemoveHabitacionModel>
    {
    }
}
