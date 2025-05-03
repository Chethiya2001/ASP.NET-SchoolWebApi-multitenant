
using System.Reflection;
using Finbuckle.MultiTenant.Abstractions;
using Finbuckle.MultiTenant.EntityFrameworkCore;
using Intrastructure.Identity.Models;
using Intrastructure.Tenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Intrastructure.Contexts;

public abstract class BaseDbContext : MultiTenantIdentityDbContext<
    Appuser,
    AppRoles,
    string,
    IdentityUserClaim<string>,
    IdentityUserRole<string>,
    IdentityUserLogin<string>,
    AppRoleClaims,
    IdentityUserToken<string>>
{

    private new SchoolTenantInfo SchoolTenantInfo { get; set; }

    protected BaseDbContext(IMultiTenantContextAccessor<SchoolTenantInfo> multiTenantContextAccessor,DbContextOptions options): base(multiTenantContextAccessor, options){

    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        if (!string.IsNullOrEmpty(SchoolTenantInfo.ConnectionString))
        {
            builder.UseSqlServer(SchoolTenantInfo.ConnectionString,
               
            option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
