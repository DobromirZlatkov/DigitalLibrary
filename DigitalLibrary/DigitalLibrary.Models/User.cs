namespace DigitalLibrary.Models
{

    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
  
    public class User : IdentityUser
    {
        //private ICollection<Work> works;
        //private ICollection<Like> likes;
        //private ICollection<Comment> comments;

        //public User()
        //{
        //    this.Works = new HashSet<Work>();
        //    this.Likes = new HashSet<Like>();
        //    this.Comments = new HashSet<Comment>();
        //}

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public int PositiveUploads { get; set; }

        public int NegativeUploads { get; set; }

        public double Rating 
        {
            set
            {
                value = CalculateRating(this.PositiveUploads, this.NegativeUploads);
            }
        }

        //public virtual ICollection<Work> Works
        //{
        //    get
        //    {
        //        return this.works;
        //    }

        //    set
        //    {
        //        this.works = value;
        //    }
        //}

        //public virtual ICollection<Like> Likes
        //{
        //    get
        //    {
        //        return this.likes;
        //    }

        //    set
        //    {
        //        this.likes = value;
        //    }
        //}

        //public virtual ICollection<Comment> Comments
        //{
        //    get
        //    {
        //        return this.comments;
        //    }

        //    set
        //    {
        //        this.comments = value;
        //    }
        //}

        private double CalculateRating(int positiveUploads, int negativeUploads)
        {
            double allUploads = (double)positiveUploads + (double)negativeUploads;
            if(allUploads > 0)
            {
                double rating = ((double)negativeUploads / allUploads) * 100;
                return rating;
            }

            return 0;
        }
    }
}
