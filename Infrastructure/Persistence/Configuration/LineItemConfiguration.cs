using StockManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagment.Infrastructure.Persistence.Configurations
{

    public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(t => t.Code);

            builder.Property(t => t.Code)
                .HasMaxLength(26)
                .IsRequired();           

            builder.Property(t => t.ElementCode)
               .HasMaxLength(26)
               .IsRequired();

            builder.Property(t => t.UnitAmount)
                //.HasPrecision(18, 6)
                .IsRequired();

            builder.Property(t => t.Quantity)
                //.HasPrecision(18, 6)
                .IsRequired();

            builder.Property(t => t.TaxableAmount)
               // .HasPrecision(18, 6)
                .IsRequired();

            builder.Property(t => t.TaxType)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.Remark)
                .HasMaxLength(100);

            builder.HasOne<Voucher>()
              .WithMany()
              .HasForeignKey(p => p.VoucherCode)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}