using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberAcademy.Web.Models
{
    public class AppUser: IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class AppRole: IdentityRole<int, AppUserRole>
    {

    }
    public class AppUserLogin: IdentityUserLogin<int>
    {
    }

    public class AppUserRole: IdentityUserRole<int>
    {

    }

    public class AppUserClaim: IdentityUserClaim<int>
    {

    }
}