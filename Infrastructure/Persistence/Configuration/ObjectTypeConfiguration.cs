using StockManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagment.Infrastructure.Persistence.Configurations
{
    public class ObjectTypeConfiguration : IEntityTypeConfiguration<ObjectType>
    {
        public void Configure(EntityTypeBuilder<ObjectType> builder)
        {
            builder.HasKey(t => t.Code);

            builder.Property(t => t.Code)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Active)
               .IsRequired();

            builder.Property(t => t.Remark)
                .HasMaxLength(100);
        }
    }
}
