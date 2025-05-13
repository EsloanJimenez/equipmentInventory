using AutoMapper;
using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;

namespace EquipmentInventory.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region "Equipment"
            CreateMap<EquipmentDTO, Equipment>();
            CreateMap<Equipment, EquipmentDTO>();
            #endregion

            #region "EquipmentType"
            CreateMap<EquipmentType, EquipmentTypeDTO>();
            CreateMap<EquipmentTypeDTO, EquipmentType>();
            #endregion

            #region "MaintenanceTask"
            CreateMap<MaintenanceTaskDTO, MaintenanceTask>();
            CreateMap<MaintenanceTask, MaintenanceTaskDTO>();
            #endregion

            #region "EquipmentMaintenance"
            CreateMap<EquipmentMaintenanceDTO, EquipmentMaintenance>();
            CreateMap<EquipmentMaintenance, EquipmentMaintenanceDTO>();
            #endregion
        }
    }
}
