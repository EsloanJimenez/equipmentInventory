namespace EquipmentInventory.Domain.Core
{
    public class BaseAuditory : BaseId
    {
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
