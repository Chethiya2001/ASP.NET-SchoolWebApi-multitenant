

using Finbuckle.MultiTenant.EntityFrameworkCore.Stores.EFCoreStore;
using Microsoft.EntityFrameworkCore;

namespace Intrastructure.Tenancy;


public class TenantDbContext(DbContextOptions<TenantDbContext> options) : EFCoreStoreDbContext<SchoolTenantInfo>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SchoolTenantInfo>()
            .ToTable("Tenants", "Multitenancy");
    }
}