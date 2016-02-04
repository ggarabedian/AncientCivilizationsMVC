namespace AncientCivilizations.Data.Repositories
{
    using System;
    using System.Collections.Generic;

    using Data.Contracts;
    using Models;

    public class AncientCivilizationsData : IAncientCivilizationsData
    {
        private readonly IAncientCivilizationsDbContext context;

        private readonly IDictionary<Type, object> repositories;

        // TODO: Remove?
        public AncientCivilizationsData()
            : this(new AncientCivilizationsDbContext())
        {
        }

        public AncientCivilizationsData(IAncientCivilizationsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IAncientCivilizationsDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IGenericRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public IGenericRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public IGenericRepository<Video> Videos
        {
            get
            {
                return this.GetRepository<Video>();
            }
        }

        public IGenericRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IGenericRepository<Civilization> Civilizations
        {
            get
            {
                return this.GetRepository<Civilization>();
            }
        }

        public IGenericRepository<Location> Locations
        {
            get
            {
                return this.GetRepository<Location>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeof(T)];
        }
    }
}
