
using Microsoft.AspNetCore.Identity;

namespace Intrastructure.Identity.Models;

    public class AppRoles:IdentityRole
    {

        public string Discription{get;set;}
    }
