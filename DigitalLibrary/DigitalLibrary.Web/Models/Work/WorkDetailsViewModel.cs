namespace DigitalLibrary.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using DigitalLibrary.Logic;
    using DigitalLibrary.Models;
    using DigitalLibrary.Web.Models.Comments;

    public class WorkDetailsViewModel
    {
        public static Expression<Func<Work, WorkDetailsViewModel>> FromWork
        {
            get
            {
                return w => new WorkDetailsViewModel
                {
                    Id = w.Id,
                    Title = w.Title,
                    Description = w.Description,
                    Year = w.Year,
                    ZipFileLink = w.ZipFileLink,
                    PictureLink = w.PictureLink,
                    AuthorId = w.AuthorId,
                    AuthorName = w.Author.Name,
                    UploadedBy = w.UploadedBy.UserName,
                    Genre = w.Genre.GenreName,
                    LikesCount = w.Likes.Count(),
                    Comments = w.Comments.AsQueryable().Select(CommentViewModel.FromComment)
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public string ZipFileLink { get; set; }

        public string PictureLink { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string UploadedBy { get; set; }

        public string Genre { get; set; }

        public int LikesCount { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public double LikesRate
        {
            get
            {
                return PercentageCalculator.CalculatePersentage(this.LikesCount, 100);
            } 
        }
    }
}