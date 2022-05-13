using System.Threading;
using System.Threading.Tasks;

using System.Reflection;
using Application.Common.Interfaces;
using StockManagment.Domain.Common;
using StockManagment.Domain.Entities;
using Infrastructure.Identity;
//using IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
        //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Consignee> Consignees => Set<Consignee>();
        public DbSet<Element> Elements => Set<Element>();
        public DbSet<LineItem> LineItems => Set<LineItem>();
        public DbSet<ObjectType> ObjectTypes => Set<ObjectType>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Voucher> Vouchers => Set<Voucher>();
        public DbSet<RoleModel> RoleModels => Set<RoleModel>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
