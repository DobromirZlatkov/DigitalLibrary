namespace DigitalLibrary.Models
{
    using System;

    public class Like
    {
        public int Id { get; set; }

        public string LikedById { get; set; }

        public virtual User LikedBy { get; set; }

        public int WorkId { get; set; }

        public virtual Work Work { get; set; }
    }
}
