namespace DigitalLibrary.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using DigitalLibrary.Data.Repositories;
    using DigitalLibrary.Models;

    public class LibraryData : ILibraryData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public LibraryData()
            : this(new LibraryDbContext())
        {
        }

        public LibraryData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }


        public IRepository<Author> Authors
        {
            get
            {
                return this.GetRepository<Author>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                return this.GetRepository<Genre>();
            }
        }

        public IRepository<Like> Likes
        {
            get
            {
                return this.GetRepository<Like>();
            }
        }

        public IRepository<Work> Works
        {
            get
            {
                return this.GetRepository<Work>();
            }
        }

        //public IRepository<WorkType> WorkTypes
        //{
        //    get
        //    {
        //        return this.GetRepository<WorkType>();
        //    }
        //}


        public int SaveChanges()
        {
            try
            {
                return this.context.SaveChanges();
            }
            catch (Exception)
            {
                return this.context.SaveChanges();
            }
            
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

    }
}
