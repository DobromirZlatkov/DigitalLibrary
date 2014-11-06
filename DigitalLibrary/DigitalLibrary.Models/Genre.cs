namespace DigitalLibrary.Models
{
    using System.Collections.Generic;

    public class Genre
    {
        private ICollection<Work> works;

        public Genre()
        {
            this.Works = new HashSet<Work>();
        }

        public int Id { get; set; }

        public string GenreName { get; set; }

        public virtual ICollection<Work> Works
        {
            get { return this.works; }
            set { this.works = value; }
        }
    }
}
