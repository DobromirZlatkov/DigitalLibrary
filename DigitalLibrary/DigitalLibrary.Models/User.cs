namespace DigitalLibrary.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using DigitalLibrary.Logic;

    public class User : IdentityUser
    {
        private ICollection<Like> likes;

        public User()
        {
            this.Likes = new HashSet<Like>();
        }

        public int PositiveUploads { get; set; }

        public int NegativeUploads { get; set; }

        public double Rating
        {
            get
            {
                return PercentageCalculator.CalculatePersentage(this.NegativeUploads, this.PositiveUploads);
            }
        }

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }

            set
            {
                this.likes = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
