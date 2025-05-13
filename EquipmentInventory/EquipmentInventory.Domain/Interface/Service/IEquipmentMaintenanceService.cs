using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;

namespace EquipmentInventory.Domain.Interface.Service
{
    public interface IEquipmentMaintenanceService : IBaseService<EquipmentMaintenance, EquipmentMaintenanceDTO>
    {
        Task CreateEquipmentMaintenance(EquipmentMaintenanceDTO equipmentMaintenanceDTO);
        Task UpdateEquipmentMaintenance(EquipmentMaintenanceDTO equipmentMaintenanceDTO);
        Task RemoveEquipmentMaintenance(EquipmentMaintenanceDTO equipmentMaintenanceDTO);
        Task<IEnumerable<int>> GetEquimentsIdsByTaskId(int taskId);
    }
}
