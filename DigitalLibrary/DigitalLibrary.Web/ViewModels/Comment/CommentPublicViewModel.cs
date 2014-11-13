namespace DigitalLibrary.Web.ViewModels.Comment
{
    using System;
    using System.Linq.Expressions;

    using DigitalLibrary.Models;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CommentPublicViewModel
    {
        public static Expression<Func<Comment, CommentPublicViewModel>> FromComment
        {
            get
            {
                return w => new CommentPublicViewModel
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

<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/ViewModels/Comment/CommentPublicViewModel.cs
        //[Column(TypeName = "DateTime2")]
        public DateTime? DatePosted { get; set; }
=======
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Models/Comments/CommentViewModel.cs
    }
}