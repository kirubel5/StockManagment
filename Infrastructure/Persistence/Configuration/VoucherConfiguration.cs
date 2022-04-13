using StockManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagment.Infrastructure.Persistence.Configurations
{

    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(t => t.Code);

            builder.Property(t => t.Code)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.TimeStamp)
                .IsRequired();

            builder.Property(t => t.SubTotal)
                .HasPrecision(18,6)
                .IsRequired();

            builder.Property(t => t.GrandTotal)
                .HasPrecision(18, 6)
                .IsRequired();

            builder.Property(t => t.Void)
                .IsRequired();

            builder.Property(t => t.Unit)
                .HasMaxLength(26);

            builder.Property(t => t.LastOperation)
                .HasMaxLength(26);

            builder.Property(t => t.Remark)
                .HasMaxLength(100);

            builder
            .HasMany(b => b.LineItems)
            .WithOne();
        }
    }
}
