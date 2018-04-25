namespace CyberAcademy.Web.Migrations
{
    using CyberAcademy.Web.DataAccess;
    using CyberAcademy.Web.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CyberAcademy.Web.DataAccess.AcademyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CyberAcademy.Web.DataAccess.AcademyDbContext context)
        {
            string username = "admin@cyberspace.com";
            string password = "admin";
            string role = "ADMIN";

            //IUserStore<Contact> contactStore = new UserStore<Contact>(new AcademyDbContext());
            //UserManager<Contact, string> userMgr = new UserManager<Contact, string>(contactStore);
            var userMgr = Startup.UserManagerFactory.Invoke();


            if (userMgr.FindByName(username) != null)
                return;


            var appUser = new AppUser()
            {
                UserName = username,
                CreatedOn = DateTime.Now,
                Name = "Prolifik Lexzy",
                Email = username,
                IsActive = true,
                EmailConfirmed = true,
            };
            var result = userMgr.Create<AppUser,int>(appUser, password);

            var roleMgr = Startup.RoleManagerFactory.Invoke();


            if (!roleMgr.RoleExists(role))
            {
                var irole = new AppRole() { Name = role };
                roleMgr.Create<AppRole,int>(irole);
            }

            if (!userMgr.IsInRole<AppUser, int>(appUser.Id, role))
            {
                userMgr.AddToRole<AppUser, int>(appUser.Id, role);
            }

            //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
                //  to avoid creating duplicate seed data. E.g.
                //
                //    context.People.AddOrUpdate(
                //      p => p.FullName,
                //      new Person { FullName = "Andrew Peters" },
                //      new Person { FullName = "Brice Lambson" },
                //      new Person { FullName = "Rowan Miller" }
                //    );
                //
        }
    }
}
