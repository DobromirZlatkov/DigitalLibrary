namespace DigitalLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Work
    {
        private ICollection<Like> likes;
        private ICollection<Comment> comments;

        public Work()
        {
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        [DefaultValue(false)]
        public bool IsApproved { get; set; }

        public string ZipFileLink { get; set; }

        [DefaultValue("https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSQDIgjwuK3j9gJAGrIX6HlVnjoA6OL2qPhQRxlq0GjHxG88HvTX6BsDoz_")]
        public string PictureLink { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public string UploadedById { get; set; }

        public virtual User UploadedBy { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
