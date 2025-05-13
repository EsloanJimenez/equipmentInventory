using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;

namespace EquipmentInventory.Domain.Interface.Service
{
    public interface IEquipmentService : IBaseService<Equipment, EquipmentDTO>
    {
        Task CreateEquipment(EquipmentDTO equipmentDTO);
        Task UpdateEquipment(EquipmentDTO equipmentDTO);
        Task RemoveEquipment(EquipmentDTO equipmentDTO);
    }
}
