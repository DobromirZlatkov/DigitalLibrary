namespace DigitalLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Author
    {
        private ICollection<Work> works;

        public Author()
        {
            this.Works = new HashSet<Work>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        [DefaultValue("http://1.bp.blogspot.com/-yK2MsBw-qSQ/TW09QUzAOVI/AAAAAAAAAJ0/9SCB5LvhqdQ/s1600/writer%2B2-737732.gif")]
        public string PictureUrl { get; set; }

        public virtual ICollection<Work> Works
        {
            get { return this.works; }
            set { this.works = value; }
        }
    }
}
