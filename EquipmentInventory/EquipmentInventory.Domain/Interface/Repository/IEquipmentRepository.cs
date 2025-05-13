using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;

namespace EquipmentInventory.Domain.Interface.Repository
{
    public interface IEquipmentRepository : IBaseRepository<Equipment, EquipmentDTO>
    {
    }
}
