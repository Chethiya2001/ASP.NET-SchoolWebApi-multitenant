using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Finbuckle.MultiTenant.Abstractions;
using Intrastructure.Tenancy;
using Microsoft.EntityFrameworkCore;
using static Intrastructure.Contexts.DbConfigurations;

namespace Intrastructure.Contexts;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(
        IMultiTenantContextAccessor<SchoolTenantInfo>multiTenantContextAccessor,
         DbContextOptions<ApplicationDbContext> options)
          : base(multiTenantContextAccessor, options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {

        optionsBuilder.UseSqlServer("Server=DESKTOP-DT15GD4\\SQLEXPRESS;Database=SchoolSharedDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

  
        modelBuilder.Entity<ApplicationUserRoleConfig>().HasNoKey();
    }

    public DbSet<School> Schools=> Set<School>();
}
