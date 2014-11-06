namespace DigitalLibrary.Models
{
    using System.Collections.Generic;

    public class Work
    {
        private ICollection<Like> likes;
        //private ICollection<Genre> genres;
        private ICollection<Comment> comments;

        public Work()
        {
            this.Likes = new HashSet<Like>();
           // this.Genres = new HashSet<Genre>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string ZipFileLink { get; set; }

        public string PdfLink { get; set; }

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

        //public virtual ICollection<Genre> Genres
        //{
        //    get { return this.genres; }
        //    set { this.genres = value; }
        //}

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
