using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;

namespace EquipmentInventory.Domain.Interface.Repository
{
    public interface IMaintenanceTaskRepository : IBaseRepository<MaintenanceTask, MaintenanceTaskDTO>
    {
    }
}
