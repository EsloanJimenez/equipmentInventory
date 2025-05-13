using AutoMapper;
using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Infrastructure.Context;

namespace EquipmentInventory.Infrastructure.Repository
{
    public class EquipmentTypeRepository : BaseRepository<EquipmentType, EquipmentTypeDTO>, IEquipmentTypeRepository
    {
        public EquipmentTypeRepository(EquipmentInventoryContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
