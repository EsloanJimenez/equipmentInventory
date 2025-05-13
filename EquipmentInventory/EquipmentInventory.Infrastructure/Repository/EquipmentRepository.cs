using AutoMapper;
using EquipmentInventory.Domain.DTO;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Domain.Interface.Repository;
using EquipmentInventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Infrastructure.Repository
{
    public class EquipmentRepository : BaseRepository<Equipment, EquipmentDTO>, IEquipmentRepository
    {
        public EquipmentRepository(EquipmentInventoryContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<List<EquipmentDTO>> GetAll()
        {
            return await _context.Equipment
                .Select(e => new EquipmentDTO
                {
                    Id = e.Id,
                    Brand = e.Brand,
                    Model = e.Model,
                    EquipmentTypeId = e.EquipmentTypeId,
                    Description = e.EquipmentTypeNav.Description,
                    PurchaseDate = e.PurchaseDate,
                    SerialNumber = e.SerialNumber
                }).ToListAsync();
        }
    }
}
