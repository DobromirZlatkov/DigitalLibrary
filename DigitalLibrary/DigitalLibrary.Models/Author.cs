namespace DigitalLibrary.Models
{
    using System.Collections.Generic;

    public class Author
    {
        private ICollection<Work> works;

        public Author()
        {
            this.Works = new HashSet<Work>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public virtual ICollection<Work> Works
        {
            get { return this.works; }
            set { this.works = value; }
        }
    }
}
