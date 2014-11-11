namespace DigitalLibrary.Data
{
    using System.Data.Entity;

    using DigitalLibrary.Data.Migrations;
    using DigitalLibrary.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
   
    public class LibraryDbContext : IdentityDbContext<User>
    {
        public LibraryDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryDbContext, Configuration>());
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Work> Works { get; set; }

        public static LibraryDbContext Create()
        {
            return new LibraryDbContext();
        }
    }
}
