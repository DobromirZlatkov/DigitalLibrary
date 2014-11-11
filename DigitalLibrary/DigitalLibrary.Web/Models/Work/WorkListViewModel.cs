namespace DigitalLibrary.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using DigitalLibrary.Models;

    public class WorkListViewModel
    {
        //private static string serverPath = HttpContext.Current.Server.MapPath("~/~/");

        public static Expression<Func<Work, WorkListViewModel>> FromWork
        {
            get
            {
                return w => new WorkListViewModel
                {
                    Id = w.Id,
                    Title = w.Title,
                    Year = w.Year,
                    ZipFileLink = w.ZipFileLink,
                    PictureLink =  w.PictureLink,
                    AuthorName = w.Author.Name,
                    AuthorId = w.AuthorId,
                    LikesCount = w.Likes.Count(),
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string ZipFileLink { get; set; }

        public string PictureLink { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId{ get; set; }

        public int LikesCount { get; set; }
    }
}