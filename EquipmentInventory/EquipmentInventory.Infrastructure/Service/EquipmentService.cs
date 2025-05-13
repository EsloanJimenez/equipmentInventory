using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Domain.Interface.Service;

namespace EquipmentInventory.Infrastructure.Service
{
    public class EquipmentService : BaseService<Equipment, EquipmentDTO>, IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentService(IEquipmentRepository equipmentRepository) : base(equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task CreateEquipment(EquipmentDTO equipmentDto)
        {
            var equipment = new Equipment
            {
                Brand = equipmentDto.Brand,
                Model = equipmentDto.Model,
                EquipmentTypeId = equipmentDto.EquipmentTypeId,
                PurchaseDate = equipmentDto.PurchaseDate,
                SerialNumber = equipmentDto.SerialNumber,
            };

            await base.Add(equipment);
        }

        public async Task UpdateEquipment(EquipmentDTO equipmentDto)
        {
            var equipmentToUpdate = await _equipmentRepository.GetEntityById(equipmentDto.Id);

            equipmentToUpdate.Brand = equipmentDto.Brand;
            equipmentToUpdate.Model = equipmentDto.Model;
            equipmentToUpdate.EquipmentTypeId = equipmentDto.EquipmentTypeId;
            equipmentToUpdate.PurchaseDate = equipmentDto.PurchaseDate;
            equipmentToUpdate.SerialNumber = equipmentDto.SerialNumber;

            equipmentToUpdate.ModifyDate = DateTime.Now;

            await base.Update(equipmentToUpdate);
        }

        public async Task RemoveEquipment(EquipmentDTO equipmentDto)
        {
            var equipmentToRemove = await _equipmentRepository.GetEntityById(equipmentDto.Id);

            equipmentToRemove.DeletedDate = DateTime.Now;
            equipmentToRemove.Deleted = true;

            await base.Update(equipmentToRemove);
        }
    }
}
