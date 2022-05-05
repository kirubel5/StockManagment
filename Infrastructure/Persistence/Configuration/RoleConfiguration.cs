using Microsoft.EntityFrameworkCore;
using StockManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleModel>    
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.ConsigneeCreate)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.ConsigneeRead)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.ConsigneeUpdate)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.ConsigneeDelete)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.ElementCreate)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.ElementRead)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.ElementUpdate)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.ElementDelete)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.PersonCreate)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.PersonRead)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.PersonUpdate)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.PersonDelete)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.VoucherCreate)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.VoucherRead)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.VoucherUpdate)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.VoucherDelete)
                .HasMaxLength(26)
                .IsRequired();

        }
    }
}
