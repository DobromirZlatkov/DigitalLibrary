namespace DigitalLibrary.Data
{
    using DigitalLibrary.Data.Repositories;
    using DigitalLibrary.Models;

    public interface ILibraryData
    {
        IRepository<User> Users { get; }

        IRepository<Author> Authors { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Genre> Genres { get; }

        IRepository<Like> Likes { get; }

        IRepository<Work> Works { get; }

        int SaveChanges();
    }
}
