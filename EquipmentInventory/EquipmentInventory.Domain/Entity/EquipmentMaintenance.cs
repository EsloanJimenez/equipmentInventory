using EquipmentInventory.Domain.Core;

namespace EquipmentInventory.Domain.Entity
{
    public class EquipmentMaintenance
    {

        public int EquipmentId { get; set; }
        public int MaintenanceTaskId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual MaintenanceTask MaintenanceTask { get; set; }
    }
}
