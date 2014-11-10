namespace DigitalLibrary.Web.Models
{
    using System;
    using System.Linq.Expressions;

    using DigitalLibrary.Models;

    public class AuthorListViewModel
    {
        public static Expression<Func<Author, AuthorListViewModel>> FromAuthor
        {
            get
            {
                return a => new AuthorListViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}