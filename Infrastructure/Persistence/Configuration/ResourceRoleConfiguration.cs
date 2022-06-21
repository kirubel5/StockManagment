using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class ResourceRoleConfiguration : IEntityTypeConfiguration<ResourceRole>
    {
        public void Configure(EntityTypeBuilder<ResourceRole> builder)
        {
            builder.Property(x => x.Id)
               .HasDefaultValueSql("NEWID()");

            builder.Property(x => x.ResourceId)
               .IsRequired();

            builder.Property(t => t.RoleId)
               .IsRequired();
        }
    }
}
