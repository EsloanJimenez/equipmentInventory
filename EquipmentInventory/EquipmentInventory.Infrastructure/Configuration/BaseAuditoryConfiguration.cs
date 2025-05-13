using EquipmentInventory.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentInventory.Infrastructure.Configuration
{
    public class BaseAuditoryConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseAuditory
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(x => !x.Deleted);

            builder.Property(ba => ba.CreationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(ba => ba.ModifyDate)
                .IsRequired(false);

            builder.Property(ba => ba.DeletedDate)
                .IsRequired(false);

            builder.Property(ba => ba.Deleted);
        }
    }
}
