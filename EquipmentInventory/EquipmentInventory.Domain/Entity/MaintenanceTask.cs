using EquipmentInventory.Domain.Core;

namespace EquipmentInventory.Domain.Entity
{
    public class MaintenanceTask : BaseAuditory
    {
        public string Description { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; } = new HashSet<Equipment>();

    }
}
