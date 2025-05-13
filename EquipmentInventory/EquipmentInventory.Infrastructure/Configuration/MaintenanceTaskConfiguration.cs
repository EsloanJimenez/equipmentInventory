using EquipmentInventory.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentInventory.Infrastructure.Configuration
{
    public class MaintenanceTaskConfiguration : IEntityTypeConfiguration<MaintenanceTask>
    {
        public void Configure(EntityTypeBuilder<MaintenanceTask> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.Description).IsRequired().HasMaxLength(200);

            builder.HasQueryFilter(m => !m.Deleted);
        }
    }
}
