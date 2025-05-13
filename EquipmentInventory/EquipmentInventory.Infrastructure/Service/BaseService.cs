using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Domain.Interface.Service;

namespace EquipmentInventory.Infrastructure.Service
{
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto> where TEntity : class
    {
        private readonly IBaseRepository<TEntity, TDto> _repository;
        public BaseService(IBaseRepository<TEntity, TDto> repository)
        {
            _repository = repository;
        }

        public virtual async Task<List<TDto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<TDto> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public virtual async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
        }


        public virtual async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }
        public virtual async Task Remove(TEntity entity)
        {
            await _repository.Remove(entity);
        }
    }
}
