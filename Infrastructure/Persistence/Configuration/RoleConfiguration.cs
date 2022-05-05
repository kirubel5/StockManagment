using Microsoft.EntityFrameworkCore;
using StockManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagment.Infrastructure.Persistence.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.HasKey(t => t.Name);
           // builder.HasNoKey();

            builder.Property(t => t.Name)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.ConsigneeCreate)
                .IsRequired();

            builder.Property(t => t.ConsigneeRead)
                .IsRequired();

            builder.Property(t => t.ConsigneeUpdate)
                .IsRequired();

            builder.Property(t => t.ConsigneeDelete)
                .IsRequired();

            builder.Property(t => t.ElementCreate)
                .IsRequired();

            builder.Property(t => t.ElementRead)
                .IsRequired();

            builder.Property(t => t.ElementUpdate)
                .IsRequired();

            builder.Property(t => t.ElementDelete)
                .IsRequired();

            builder.Property(t => t.PersonCreate)
                .IsRequired();

            builder.Property(t => t.PersonRead)
                .IsRequired();

            builder.Property(t => t.PersonUpdate)
                .IsRequired();

            builder.Property(t => t.PersonDelete)
                .IsRequired();

            builder.Property(t => t.VoucherCreate)
                .IsRequired();

            builder.Property(t => t.VoucherRead)
                .IsRequired();

            builder.Property(t => t.VoucherUpdate)
                .IsRequired();

            builder.Property(t => t.VoucherDelete)
                .IsRequired();

        }
    }
}
