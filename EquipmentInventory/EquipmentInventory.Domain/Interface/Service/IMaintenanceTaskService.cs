using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;

namespace EquipmentInventory.Domain.Interface.Service
{
    public interface IMaintenanceTaskService : IBaseService<MaintenanceTask, MaintenanceTaskDTO>
    {
        Task CreateMaintenanceTask(MaintenanceTaskDTO MaintenanceTaskDTO);
        Task UpdateMaintenanceTask(MaintenanceTaskDTO MaintenanceTaskDTO);
        Task RemoveMaintenanceTask(MaintenanceTaskDTO MaintenanceTaskDTO);
    }
}
