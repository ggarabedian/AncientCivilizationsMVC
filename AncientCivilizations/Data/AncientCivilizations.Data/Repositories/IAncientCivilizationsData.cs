namespace AncientCivilizations.Data.Repositories
{
    using Contracts;
    using Models;

    public interface IAncientCivilizationsData
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<Article> Articles { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Image> Images { get; }

        IGenericRepository<Video> Videos { get; }

        IGenericRepository<Civilization> Civilizations { get; }

        IGenericRepository<Location> Locations { get; }

        int SaveChanges();
    }
}
