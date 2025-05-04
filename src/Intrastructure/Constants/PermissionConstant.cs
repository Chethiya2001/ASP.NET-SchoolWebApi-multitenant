
using System.Collections.ObjectModel;

namespace Intrastructure.Constants
{
    public static class SchoolAction
    {
        public const string Read = nameof(Read);
        public const string Create = nameof(Create);
        public const string Delete = nameof(Delete);
        public const string Update = nameof(Update);
        public const string UpgradeSubscribtion = nameof(UpgradeSubscribtion);

    }
    public static class SchoolFeatures
    {
        public const string Tenant = nameof(Tenant);
        public const string School = nameof(School);
        public const string Users = nameof(Users);
        public const string Roles = nameof(Roles);
        public const string UserRoles = nameof(UserRoles);
        public const string RoleClaims = nameof(RoleClaims);
    }
    public record class SchoolPermission(string Action, string Features, string Description,string Group, bool Isbasic = false, bool IsRoot = false)
    {
        public string Name => NameFor(Action, Features);
        public static string NameFor(string action, string features) => $"Permission{features} {action}";
    }
    public static class SchoolPermissions
    {
        private static readonly SchoolPermission[] _allPermissions = [
            new SchoolPermission(SchoolAction.Create, SchoolFeatures.Tenant, "Create tenant","tenancy",false,true),
            new SchoolPermission(SchoolAction.Read, SchoolFeatures.Tenant, "Read tenant","tenancy",false,true),
            new SchoolPermission(SchoolAction.Update, SchoolFeatures.Tenant, "Update tenant","tenancy",false,true),
            new SchoolPermission(SchoolAction.Delete, SchoolFeatures.Tenant, "Delete tenant","tenancy",false,true),
            new SchoolPermission(SchoolAction.UpgradeSubscribtion, SchoolFeatures.Tenant, "Update Subscribtion tenant","tenancy",false,true),

            new SchoolPermission(SchoolAction.Create, SchoolFeatures.Users, "Create User","SystemAccess"),
            new SchoolPermission(SchoolAction.Read, SchoolFeatures.Users, "Read User","SystemAccess"),
            new SchoolPermission(SchoolAction.Update, SchoolFeatures.Users, "Update User","SystemAccess"),
            new SchoolPermission(SchoolAction.Delete, SchoolFeatures.Users, "Delete User","SystemAccess"),

            new SchoolPermission(SchoolAction.Read, SchoolFeatures.UserRoles, "Read User Role","SystemAccess"),
            new SchoolPermission(SchoolAction.Update, SchoolFeatures.UserRoles, "Update User Role","SystemAccess"),

            new SchoolPermission(SchoolAction.Create, SchoolFeatures.Roles, "Create Role","SystemAccess"),
            new SchoolPermission(SchoolAction.Read, SchoolFeatures.Roles, "Read Role","SystemAccess"),
            new SchoolPermission(SchoolAction.Update, SchoolFeatures.Roles, "Update Role","SystemAccess"),
            new SchoolPermission(SchoolAction.Delete, SchoolFeatures.Roles, "Delete Role","SystemAccess"),


            new SchoolPermission(SchoolAction.Read, SchoolFeatures.RoleClaims, "Read Role Claims/Permission","SystemAccess"),
            new SchoolPermission(SchoolAction.Update, SchoolFeatures.RoleClaims, "Update Role Claims/Permission","SystemAccess"),



            new SchoolPermission(SchoolAction.Create, SchoolFeatures.School, "Create School","Academics",true),
            new SchoolPermission(SchoolAction.Read, SchoolFeatures.School, "Read School","Academics"),
            new SchoolPermission(SchoolAction.Update, SchoolFeatures.School, "Update School","Academics"),
            new SchoolPermission(SchoolAction.Delete, SchoolFeatures.School, "Delete School","Academics"),
        ];
        public static IReadOnlyList<SchoolPermission> All { get; } = new ReadOnlyCollection<SchoolPermission>(_allPermissions);
        public static IReadOnlyList<SchoolPermission> Root { get; } = new ReadOnlyCollection<SchoolPermission>(_allPermissions
        .Where((p) => p.IsRoot).ToArray());
        public static IReadOnlyList<SchoolPermission> Admin { get; } = new ReadOnlyCollection<SchoolPermission>(_allPermissions
        .Where((p) => !p.IsRoot).ToArray());
        public static IReadOnlyList<SchoolPermission> Basic { get; } = new ReadOnlyCollection<SchoolPermission>(_allPermissions
        .Where((p) => p.Isbasic).ToArray());


        
            }
}
