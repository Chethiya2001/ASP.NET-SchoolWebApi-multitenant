using Finbuckle.MultiTenant;
using Intrastructure.Contexts;
using Intrastructure.Tenancy;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        return services
        .AddDbContext<TenantDbContext>(o =>
        o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
        .AddMultiTenant<SchoolTenantInfo>()
        .WithHeaderStrategy(TenancyConstant.tenancyIdName)
        .WithClaimStrategy(TenancyConstant.tenancyIdName)
        .WithEFCoreStore<TenantDbContext, SchoolTenantInfo>()
        .Services
        .AddDbContext<ApplicationDbContext>(op =>
        op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
        ;

    }
    public static IApplicationBuilder UseAddInfrastructure(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseMultiTenant();
    }

}
