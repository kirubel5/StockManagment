using StockManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockManagment.Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(t => t.Code);

            builder.Property(t => t.Code)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(t => t.Type)
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(t => t.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.MiddleName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.Nationality)
                .HasMaxLength(26);

            builder.Property(t => t.Active)
                .IsRequired();

            builder.Property(t => t.Remark)
                .HasMaxLength(100);

            builder
           .HasOne<ObjectType>()
           .WithMany()
           .HasForeignKey(p => p.Type)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
