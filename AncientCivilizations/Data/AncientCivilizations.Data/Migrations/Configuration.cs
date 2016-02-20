namespace AncientCivilizations.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<AncientCivilizationsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            //// TODO: Remove
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AncientCivilizationsDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var adminRole = new IdentityRole { Name = "Administrator" };
                manager.Create(adminRole);

                var userRole = new IdentityRole { Name = "User" };
                manager.Create(userRole);
            }

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                manager.PasswordValidator = new MinimumLengthValidator(4);

                var user = new User { UserName = "admin@admin.com", Email = "admin@admin.com", FullName = "Admin Admin", CreatedOn = DateTime.Now };

                var result = manager.Create(user, "admin");
                manager.AddToRole(user.Id, "Administrator");
            }
        }
    }
}
