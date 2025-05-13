using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;

namespace EquipmentInventory.Domain.Interface.Repository
{
    public interface IEquipmentMaintenanceRepository : IBaseRepository<EquipmentMaintenance, EquipmentMaintenanceDTO>
    {
        Task RemoveRangeByEquipmentsIds(int taskId, IEnumerable<int> values);
        Task AddRange(IEnumerable<EquipmentMaintenance> values);
        Task<IEnumerable<int>> GetEquimentsIdsByTaskId(int taskId);
    }
}
