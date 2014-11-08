using DigitalLibrary.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DigitalLibrary.Web.Models
{
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
                    Tags = w.Tags,
                    Year = w.Year,
                    ZipFileLink = w.ZipFileLink,
                    PictureLink = w.PictureLink,
                    AuthorId = w.AuthorId,
                    AuthorName = w.Author.Name,
                    UploadedBy = w.UploadedBy.UserName,
                    Genre = w.Genre.GenreName,
                    LikesRate = w.Likes.Count(l => l.IsPositive) - w.Likes.Count(l => !l.IsPositive),
                    Comments = w.Comments
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public int Year { get; set; }

        public string ZipFileLink { get; set; }

        public string PictureLink { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string UploadedBy { get; set; }

        public string Genre { get; set; }

        public int LikesRate { get; set; }

        public ICollection<Comment> Comments { get; set; }
   
    }
}