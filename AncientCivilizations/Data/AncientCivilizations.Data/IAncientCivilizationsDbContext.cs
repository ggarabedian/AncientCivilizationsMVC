﻿namespace AncientCivilizations.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IAncientCivilizationsDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<Article> Articles { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Video> Videos { get; set; }

        IDbSet<Picture> Images { get; set; }

        IDbSet<Civilization> Civilizations { get; set; }

        IDbSet<Location> Locations { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
