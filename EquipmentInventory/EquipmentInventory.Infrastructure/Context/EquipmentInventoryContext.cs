using EquipmentInventory.Domain.Core;
using EquipmentInventory.Domain.Entity;
using EquipmentInventory.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Infrastructure.Context
{
    public class EquipmentInventoryContext : DbContext
    {
        public EquipmentInventoryContext(DbContextOptions<EquipmentInventoryContext> op) : base(op)
        {
            
        }

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentMaintenance> EquipmentMaintenance { get; set; }
        public DbSet<EquipmentType> EquipmentType { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentMaintenanceConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceTaskConfiguration());

            foreach(var entityType in modelBuilder.Model.GetEntityTypes().Where(c => typeof(BaseAuditory).IsAssignableFrom(c.ClrType)))
            {
                var configType = typeof(BaseAuditoryConfiguration<>).MakeGenericType(entityType.ClrType);
                var configInstance = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration((dynamic)configInstance);
            }
        }
    }
}
