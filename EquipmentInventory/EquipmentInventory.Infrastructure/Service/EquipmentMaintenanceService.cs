using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Domain.Interface.Service;

namespace EquipmentInventory.Infrastructure.Service
{
    public class EquipmentMaintenanceService : BaseService<EquipmentMaintenance, EquipmentMaintenanceDTO>, IEquipmentMaintenanceService
    {
        private readonly IEquipmentMaintenanceRepository _equipmentMaintenanceRepository;
        public EquipmentMaintenanceService(IEquipmentMaintenanceRepository equipmentMaintenanceRepository) : base(equipmentMaintenanceRepository)
        {
            _equipmentMaintenanceRepository = equipmentMaintenanceRepository;
        }

        public async Task CreateEquipmentMaintenance(EquipmentMaintenanceDTO equipmentMaintenanceDTO)
        {
            var equipmentMaintenance = new EquipmentMaintenance
            {
                EquipmentId = equipmentMaintenanceDTO.EquipmentId,
                MaintenanceTaskId = equipmentMaintenanceDTO.MaintenanceTaskId,
            };

            await base.Add(equipmentMaintenance);
        }

        public async Task UpdateEquipmentMaintenance(EquipmentMaintenanceDTO equipmentMaintenanceDTO)
        {
            var equipmentMaintenanceToUpdate = await _equipmentMaintenanceRepository.GetEntityById(equipmentMaintenanceDTO.EquipmentId);

            equipmentMaintenanceToUpdate.EquipmentId = equipmentMaintenanceDTO.EquipmentId;
            equipmentMaintenanceToUpdate.MaintenanceTaskId = equipmentMaintenanceDTO.MaintenanceTaskId;

            equipmentMaintenanceToUpdate.ModifyDate = DateTime.Now;

            await base.Update(equipmentMaintenanceToUpdate);
        }
        public async Task RemoveEquipmentMaintenance(EquipmentMaintenanceDTO equipmentMaintenanceDTO)
        {
            var equipmentMaintenanceToRemove = await _equipmentMaintenanceRepository.GetEntityById(equipmentMaintenanceDTO.EquipmentId);

            equipmentMaintenanceToRemove.MaintenanceTask.DeletedDate = DateTime.Now;
            equipmentMaintenanceToRemove.MaintenanceTask.Deleted = true;

            await base.Update(equipmentMaintenanceToRemove);
        }

        public async Task<IEnumerable<int>> GetEquimentsIdsByTaskId(int taskId)
        {
            return await _equipmentMaintenanceRepository.GetEquimentsIdsByTaskId(taskId);
        }
    }
}
