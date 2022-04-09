using StockManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagment.Infrastructure.Persistence.Configurations
{
    public class ConsigneeConfiguration : IEntityTypeConfiguration<Consignee>
    {
        public void Configure(EntityTypeBuilder<Consignee> builder)
        {
            builder
                .HasKey(t => t.Code);               

            builder.Property(t => t.Code)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.TradeName)
                .HasMaxLength(50);

            builder.Property(t => t.BusinessType)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.Type)
                .HasMaxLength(26)
                .IsRequired();                

            builder.Property(t => t.Active)
                .IsRequired();

            builder.Property(t => t.Remark)
                .HasMaxLength(100);

            //builder.Property(t => t.Group)
            //    .HasMaxLength(26);

            builder
            .HasOne<ObjectType>()
            .WithMany()
            .HasForeignKey(p => p.Type);
        }
    }
}
