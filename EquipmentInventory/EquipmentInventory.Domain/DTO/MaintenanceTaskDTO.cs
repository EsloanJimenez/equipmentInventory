namespace EquipmentInventory.Domain.DTO
{
    public class MaintenanceTaskDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<EquipmentDTO> Equipments { get; set; } = new HashSet<EquipmentDTO>();
    }
}
