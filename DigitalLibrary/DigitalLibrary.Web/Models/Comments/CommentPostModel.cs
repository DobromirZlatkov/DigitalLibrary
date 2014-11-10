namespace DigitalLibrary.Web.Models.Comments
{
    using System;

    public class CommentPostModel
    {
        public string Content { get; set; }
            
        public string PostedBy{ get; set; }

        public int WorkId { get; set; }
    }
}