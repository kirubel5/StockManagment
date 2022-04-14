using StockManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagment.Infrastructure.Persistence.Configurations
{

    public class ElementConfiguration : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.HasKey(t => t.Code);

            builder.Property(t => t.Code)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(26)
                .IsRequired();           

            builder.Property(t => t.Active)
                .IsRequired();

            builder.Property(t => t.UOM)
                .IsRequired();

            builder.Property(t => t.Remark)
                .HasMaxLength(200);
         
        }
    }
}