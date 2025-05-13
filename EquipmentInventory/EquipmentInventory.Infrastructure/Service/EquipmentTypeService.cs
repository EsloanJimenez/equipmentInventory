using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Domain.Interface.Service;

namespace EquipmentInventory.Infrastructure.Service
{
    public class EquipmentTypeService : BaseService<EquipmentType, EquipmentTypeDTO>, IEquipmentTypeService
    {
        public EquipmentTypeService(IBaseRepository<EquipmentType, EquipmentTypeDTO> repository) : base(repository)
        {
        }
    }
}
