using AutoMapper;
using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Infrastructure.Repository
{
    public class EquipmentMaintenanceRepository : BaseRepository<EquipmentMaintenance, EquipmentMaintenanceDTO>, IEquipmentMaintenanceRepository
    {
        public EquipmentMaintenanceRepository(EquipmentInventoryContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task RemoveRangeByEquipmentsIds(int taskId, IEnumerable<int> values)
        {
            var equipmentMaintenances = _context.EquipmentMaintenance
                .Where(e => e.MaintenanceTaskId == taskId && values.Contains(e.EquipmentId)).ToList();


            _context.EquipmentMaintenance.RemoveRange(equipmentMaintenances);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<EquipmentMaintenance> values)
        {
            await _context.EquipmentMaintenance.AddRangeAsync(values);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<int>> GetEquimentsIdsByTaskId(int taskId)
        {
            return await _context.EquipmentMaintenance
                .AsNoTracking()
                .Where(t => t.MaintenanceTaskId == taskId)
                .Select(e => e.EquipmentId).ToListAsync();
        }
    }
}
