namespace AncientCivilizations.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class AncientCivilizationsDbContext : IdentityDbContext<User>, IAncientCivilizationsDbContext
    {
        public AncientCivilizationsDbContext()
            : base("AncientCivilizationsConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Video> Videos { get; set; }

        public IDbSet<Picture> Pictures { get; set; }

        public IDbSet<Civilization> Civilizations { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public static AncientCivilizationsDbContext Create()
        {
            return new AncientCivilizationsDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
