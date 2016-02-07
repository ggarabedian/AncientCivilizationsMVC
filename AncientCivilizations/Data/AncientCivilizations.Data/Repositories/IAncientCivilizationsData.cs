namespace AncientCivilizations.Data.Repositories
{
    using Contracts;
    using Models;

    public interface IAncientCivilizationsData
    {
        IAncientCivilizationsDbContext Context { get; }

        IGenericRepository<User> Users { get; }

        IGenericRepository<Article> Articles { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Picture> Pictures { get; }

        IGenericRepository<Video> Videos { get; }

        IGenericRepository<Civilization> Civilizations { get; }

        IGenericRepository<Location> Locations { get; }

        int SaveChanges();
    }
}
