using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Intrastructure.Identity.Models
{
    public class AppRoleClaims : IdentityRoleClaim<string>
    {
        public string Description { get; set; }
         public string Group { get; set; }
        
    }
}