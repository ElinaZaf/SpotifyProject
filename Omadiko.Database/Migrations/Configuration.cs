namespace Omadiko.Database.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Omadiko.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Omadiko.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Omadiko.Database.ApplicationDbContext context)
        {
           




            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };



                manager.Create(role);
            }


            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(x => x.UserName == "admin@admin.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin@admin.net",
                    Email = "admin@admin.net",
                    PasswordHash = PasswordHash.HashPassword("Admin1!")
                };



                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }








        }
    }
}
