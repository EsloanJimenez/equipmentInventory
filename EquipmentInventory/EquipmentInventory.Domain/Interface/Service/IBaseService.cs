﻿namespace EquipmentInventory.Domain.Interface.Service
{
    public interface IBaseService<TEntity, TDto> where TEntity : class
    {
        Task<List<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}
