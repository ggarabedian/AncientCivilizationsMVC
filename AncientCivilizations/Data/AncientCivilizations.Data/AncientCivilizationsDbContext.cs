namespace AncientCivilizations.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Contracts;
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

        public IDbSet<Image> Images { get; set; }

        public static AncientCivilizationsDbContext Create()
        {
            return new AncientCivilizationsDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
