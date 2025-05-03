using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Intrastructure.Identity.Models;

public class Appuser : IdentityUser
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public string Refreshedtoken { get; set; }
    public DateTime RefreshedtokenBytime { get; set; }

}
