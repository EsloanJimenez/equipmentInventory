using EquipmentInventory.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EquipmentInventory.Infrastructure.Configuration
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Brand)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PurchaseDate)
                .IsRequired();

            builder.Property(e => e.SerialNumber)
                .IsRequired(false);

            builder.HasOne(e => e.EquipmentTypeNav)
                .WithMany(e => e.Equipments)
                .HasForeignKey(e => e.EquipmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
            .HasMany(e => e.Tasks)
            .WithMany(e => e.Equipments)
            .UsingEntity<EquipmentMaintenance>();

            builder.HasQueryFilter(m => !m.Deleted);
        }
    }
}
