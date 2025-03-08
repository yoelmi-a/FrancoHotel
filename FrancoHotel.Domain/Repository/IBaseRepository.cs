using System.Linq.Expressions;
using FrancoHotel.Domain.Base;

namespace FrancoHotel.Domain.Repository
{
    /// <summary>
    /// Interfaz de herencia para los repositorios.
    /// </summary>
    /// <typeparam name="TEntity">Entidad</typeparam>
    /// <typeparam name="Ttype">El Tipo de dato del primmary Key para realizar consulta.</typeparam>
    public interface IBaseRepository<TEntity, Ttype> where TEntity : class
    {
        Task<OperationResult> SaveEntityAsync(TEntity entity);
        Task<OperationResult> UpdateEntityAsync(TEntity entity);
        Task<TEntity?> GetEntityByIdAsync(Ttype id);
        Task<List<TEntity>> GetAllAsync();
        Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
        Task<OperationResult> RemoveEntityAsync(Ttype id, Ttype idUsuarioMod);
    }
}
