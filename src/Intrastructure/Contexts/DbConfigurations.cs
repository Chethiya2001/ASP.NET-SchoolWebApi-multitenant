using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Finbuckle.MultiTenant;
using Intrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrastructure.Contexts
{
    internal class DbConfigurations
    {
        internal class ApplicationUserConfig : IEntityTypeConfiguration<Appuser>
        {
            public void Configure(EntityTypeBuilder<Appuser> builder)
            {
                builder
                 .ToTable("Users", "Identity")
                 .IsMultiTenant();
            }
        }
         internal class ApplicationRoleConfig : IEntityTypeConfiguration<AppRoles>
        {
            public void Configure(EntityTypeBuilder<AppRoles> builder)
            {
                builder
                 .ToTable("Roles", "Identity")
                 .IsMultiTenant();
            }
        }
          internal class ApplicationRoleClaimsConfig : IEntityTypeConfiguration<AppRoleClaims>
        {
            public void Configure(EntityTypeBuilder<AppRoleClaims> builder)
            {
                builder
                 .ToTable("RoleClaims", "Identity")
                 .IsMultiTenant();
            }
        }
          internal class ApplicationUserRoleConfig : IEntityTypeConfiguration<ApplicationUserRoleConfig>
        {
            public void Configure(EntityTypeBuilder<ApplicationUserRoleConfig> builder)
            {
                builder
                 .ToTable("UserRole", "Identity")
                 .IsMultiTenant();
            }
        }
           internal class ApplicationUserClaimsConfig : IEntityTypeConfiguration<IdentityUserClaim<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
            {
                builder
                 .ToTable("UserClaims", "Identity")
                 .IsMultiTenant();
            }
        }
              internal class ApplicationUserLoginConfig : IEntityTypeConfiguration<IdentityUserToken<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
            {
                builder
                 .ToTable("UserToken", "Identity")
                 .IsMultiTenant();
            }
        }

        internal class SchoolConfig : IEntityTypeConfiguration<School>
        {
            public void Configure(EntityTypeBuilder<School> builder)
            {
                builder.ToTable("Schools", "Acadamies").IsMultiTenant();
                builder.Property(school=> school.Name).IsRequired().HasMaxLength(60);
            }
        }
    }

}