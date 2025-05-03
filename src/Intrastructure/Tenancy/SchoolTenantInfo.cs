

using Finbuckle.MultiTenant.Abstractions;

namespace Intrastructure.Tenancy;

public class SchoolTenantInfo : ITenantInfo
{
    public string Id { get; set; }
    public string Identifier { get; set; }
    public string Name { get; set; }
    public string ConnectionString { get; set; }
    public string Email { get; set; }
    public string Firstname { get; set; }
    public string Latname { get; set; }
    public DateTime ValidUpTo { get; set; }
    public bool isActive { get; set; }
}
