using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intrastructure.Constants
{
    public static class RoleContant
    {
        public const string Admin  = nameof(Admin);
        public const string Basic  = nameof(Basic);

        public static IReadOnlyList<string> DefaultRoles {get;}= new ReadOnlyCollection<string>([
            Admin,
            Basic
        ]);
        public static bool IsDefaultRole(string rolename)=>DefaultRoles.Contains(rolename);
    }
}