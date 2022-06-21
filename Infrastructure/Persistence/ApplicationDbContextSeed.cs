using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Admin");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var cashierRole = new IdentityRole("Cashier");

            if (roleManager.Roles.All(r => r.Name != cashierRole.Name))
            {
                await roleManager.CreateAsync(cashierRole);
            }

            var managerRole = new IdentityRole("Manager");

            if (roleManager.Roles.All(r => r.Name != managerRole.Name))
            {
                await roleManager.CreateAsync(managerRole);
            }

            var administrator = new ApplicationUser { UserName = "admin", Email = "admin@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }            
        }

        public static async Task SeedResourcesAsync(ApplicationDbContext context)
        {
            var consigneeResource = new Resource { Name = "Consignee" };
            var elementResource = new Resource { Name = "Element" };
            var personResource = new Resource { Name = "Person" };
            var voucherResource = new Resource { Name = "Voucher" };
            var roleResource = new Resource { Name = "Role" };

            if (context.Resources.All(u => u.Name != consigneeResource.Name))
            {
                await context.Resources.AddAsync(consigneeResource);
                await context.SaveChangesAsync();
            }

            if (context.Resources.All(u => u.Name != elementResource.Name))
            {
                await context.Resources.AddAsync(elementResource);
                await context.SaveChangesAsync();
            }

            if (context.Resources.All(u => u.Name != personResource.Name))
            {
                await context.Resources.AddAsync(personResource);
                await context.SaveChangesAsync();
            }

            if (context.Resources.All(u => u.Name != voucherResource.Name))
            {
                await context.Resources.AddAsync(voucherResource);
                await context.SaveChangesAsync();
            }

            if (context.Resources.All(u => u.Name != roleResource.Name))
            {
                await context.Resources.AddAsync(roleResource);
                await context.SaveChangesAsync();
            }
        }
    }
}
