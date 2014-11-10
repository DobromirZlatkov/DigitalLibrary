namespace DigitalLibrary.Models
{
    using System;

    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DatePosted { get; set; }

        public string PostedById { get; set; }

        public virtual User PostedBy { get; set; }

        public int WorkId { get; set; }

        public virtual Work Work { get; set; }
    }
}
