namespace AncientCivilizations.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IAncientCivilizationsDbContext : IDisposable
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Video> Videos { get; set; }

        IDbSet<Picture> Pictures { get; set; }

        IDbSet<Civilization> Civilizations { get; set; }

        IDbSet<Location> Locations { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
