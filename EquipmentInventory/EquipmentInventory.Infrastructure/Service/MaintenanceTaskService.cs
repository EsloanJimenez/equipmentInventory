using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Domain.Interface.Service;

namespace EquipmentInventory.Infrastructure.Service
{
    public class MaintenanceTaskService : BaseService<MaintenanceTask, MaintenanceTaskDTO>, IMaintenanceTaskService
    {
        private readonly IMaintenanceTaskRepository _maintenanceTaskRepository;
        private readonly IEquipmentMaintenanceRepository _equipmentMaintenanceRepository;
        public MaintenanceTaskService(IMaintenanceTaskRepository maintenanceTaskRepository, IEquipmentMaintenanceRepository equipmentMaintenanceRepository) : base(maintenanceTaskRepository)
        {
            _maintenanceTaskRepository = maintenanceTaskRepository;
            _equipmentMaintenanceRepository = equipmentMaintenanceRepository;
        }

        public async Task CreateMaintenanceTask(MaintenanceTaskDTO MaintenanceTaskDTO)
        {
            var equipments = MaintenanceTaskDTO.Equipments.Select(m => new EquipmentMaintenance
            {
                EquipmentId = m.Id
            }).ToList();

            var maintenanceTask = new MaintenanceTask
            {
                Description = MaintenanceTaskDTO.Description,
            };

            await base.Add(maintenanceTask);

            foreach (var item in equipments)
            {
                item.MaintenanceTaskId = maintenanceTask.Id;
            }

            await _equipmentMaintenanceRepository.AddRange(equipments);
        }


        public async Task UpdateMaintenanceTask(MaintenanceTaskDTO maintenanceTaskDTO)
        {
            var all = await _equipmentMaintenanceRepository.GetEquimentsIdsByTaskId(maintenanceTaskDTO.Id);

            var deleted = all.Where(e => !maintenanceTaskDTO.Equipments.Select(m => m.Id).Contains(e));

            await _equipmentMaintenanceRepository.RemoveRangeByEquipmentsIds(maintenanceTaskDTO.Id, deleted);

            var maintenanceTaskToUpdate = await _maintenanceTaskRepository.GetEntityById(maintenanceTaskDTO.Id);

            maintenanceTaskToUpdate.Description = maintenanceTaskDTO.Description;
            

            maintenanceTaskToUpdate.ModifyDate = DateTime.Now;

            await base.Update(maintenanceTaskToUpdate);

            var equipments = maintenanceTaskDTO.Equipments.Where(e => !all.Contains(e.Id)).Select(m => new EquipmentMaintenance
            {
                EquipmentId = m.Id,
                MaintenanceTaskId = maintenanceTaskDTO.Id
            }).ToList();



            await _equipmentMaintenanceRepository.AddRange(equipments);
        }

        public async Task RemoveMaintenanceTask(MaintenanceTaskDTO maintenanceTaskDTO)
        {
            var maintenanceTaskToRemove = await _maintenanceTaskRepository.GetEntityById(maintenanceTaskDTO.Id);

            maintenanceTaskToRemove.DeletedDate = DateTime.Now;
            maintenanceTaskToRemove.Deleted = true;

            await base.Update(maintenanceTaskToRemove);
        }
    }
}
