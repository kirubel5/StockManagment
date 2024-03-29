﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using StockManagment.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Consignee> Consignees { get; }
        DbSet<Element> Elements { get; }
        DbSet<LineItem> LineItems { get; }
        DbSet<ObjectType> ObjectTypes { get; }
        DbSet<Person> Persons { get; }
        DbSet<Voucher> Vouchers { get; }
        DbSet<Resource> Resources { get; }
        DbSet<ResourceRole> ResourceRoles { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
