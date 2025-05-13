using EquipmentInventory.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EquipmentInventory.Infrastructure.Configuration
{
    public class EquipmentMaintenanceConfiguration : IEntityTypeConfiguration<EquipmentMaintenance>
    {
        public void Configure(EntityTypeBuilder<EquipmentMaintenance> builder)
        {
            builder.HasKey(em => new {em.EquipmentId, em.MaintenanceTaskId});

            builder.HasOne(em => em.Equipment)
                .WithMany()
                .HasForeignKey(em => em.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(em => em.MaintenanceTask)
                .WithMany()
                .HasForeignKey(em => em.MaintenanceTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
