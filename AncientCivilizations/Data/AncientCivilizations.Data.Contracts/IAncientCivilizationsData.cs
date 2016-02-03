namespace AncientCivilizations.Data.Contracts
{
    using Models;

    public interface IAncientCivilizationsData
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<Article> Articles { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Image> Images { get; }

        IGenericRepository<Video> Videos { get; }

        int SaveChanges();
    }
}
