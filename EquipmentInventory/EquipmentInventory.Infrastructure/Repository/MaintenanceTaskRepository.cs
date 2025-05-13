using AutoMapper;
using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Infrastructure.Repository
{
    public class MaintenanceTaskRepository : BaseRepository<MaintenanceTask, MaintenanceTaskDTO>, IMaintenanceTaskRepository
    {
        public MaintenanceTaskRepository(EquipmentInventoryContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<List<MaintenanceTaskDTO>> GetAll()
        {
            return await _context.MaintenanceTask
                .AsNoTracking()
                .Select(e => new MaintenanceTaskDTO
                {
                    Id = e.Id,
                    Description = e.Description,
                    Equipments = e.Equipments.Select(m => new EquipmentDTO
                    {
                        Id = m.Id,
                        Brand = m.Brand,
                        Model = m.Model,
                        EquipmentTypeId = m.EquipmentTypeId,
                        Description = m.EquipmentTypeNav.Description,
                    })
                }).ToListAsync();
        }
    }
}
