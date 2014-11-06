namespace DigitalLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using DigitalLibrary.Models;

    public sealed class Configuration : DbMigrationsConfiguration<LibraryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(DigitalLibrary.Data.LibraryDbContext context)
        {
            if (context.Genres.Any())
            {
                return;
            }
            context.Genres.Add(new Genre
                {
                    GenreName = "Archaeology"
                });
            context.SaveChanges();
        }
    }
}
