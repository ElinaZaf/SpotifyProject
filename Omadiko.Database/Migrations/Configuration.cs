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
            //=================Seeding Genres====================
            Genre g1 = new Genre() { GenreKind = "Rock" };
            Genre g2 = new Genre() { GenreKind = "POP" };
            Genre g3 = new Genre() { GenreKind = "Classical Music" };
            Genre g4 = new Genre() { GenreKind = "Country" };
            Genre g5 = new Genre() { GenreKind = "Jazz" };
            Genre g6 = new Genre() { GenreKind = "Electronic" };
            Genre g7 = new Genre() { GenreKind = "Disco" };
            Genre g8 = new Genre() { GenreKind = "Instrumental" };
            Genre g9 = new Genre() { GenreKind = "Ambient" };
            Genre g10 = new Genre() { GenreKind = "Soundtrack" };
            //Genre g = new Genre() { GenreKind = "" };




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
