using System.Linq.Expressions;

namespace EquipmentInventory.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity, TDto> where TEntity : class
    {
        Task<List<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TEntity> GetEntityById(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<bool> Exists(Expression<Func<TEntity, bool>> expression);
    }
}
