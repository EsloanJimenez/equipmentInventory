using EquipmentInventory.Domain.Core;

namespace EquipmentInventory.Domain.Entity
{
    public class Equipment : BaseAuditory
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int EquipmentTypeId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? SerialNumber { get; set; }
        public virtual EquipmentType? EquipmentTypeNav { get; set; }
        public virtual ICollection<MaintenanceTask> Tasks { get; set; } = new HashSet<MaintenanceTask>();
    }
}
