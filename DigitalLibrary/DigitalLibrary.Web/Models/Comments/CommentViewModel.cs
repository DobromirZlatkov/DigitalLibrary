namespace DigitalLibrary.Web.Models.Comments
{
    using System;
    using System.Linq.Expressions;

    using DigitalLibrary.Models;

    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return w => new CommentViewModel
                {
                   Content = w.Content,
                   PostedBy = w.PostedBy.UserName,
                   DatePosted = w.DatePosted
                };
            }
        }

        public string Content { get; set; }
            
        public string PostedBy{ get; set; }

        public DateTime DatePosted {get;set;}

    }
}