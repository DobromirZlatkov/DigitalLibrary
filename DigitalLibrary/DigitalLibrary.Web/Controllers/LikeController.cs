namespace DigitalLibrary.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using DigitalLibrary.Data;
    using DigitalLibrary.Models;

    public class LikeController : BaseController
    {
        public LikeController(ILibraryData data)
            : base(data)
        {
        }

        public ActionResult Like(int id)
        {
            var workVotedFor = this.Data.Works.Find(id);
            var currentUserId = User.Identity.GetUserId();

            var canLike = !this.Data.Likes.All().Any(x => x.WorkId == workVotedFor.Id && x.LikedById == currentUserId);

            if (canLike)
            {
                var newLike = new Like
                {
                    LikedById = currentUserId,
                    WorkId = workVotedFor.Id
                };

                workVotedFor.Likes.Add(newLike);
                this.Data.SaveChanges();
            }

            return this.Content(workVotedFor.Likes.Count().ToString());
        }

        public ActionResult Dislike(int id)
        {
            var context = new LibraryDbContext();

            var currentUserId = User.Identity.GetUserId();
            var currentUser = this.Data.Users.Find(currentUserId);

            var yourLike = this.Data.Likes.All().Where(x => x.WorkId == id && x.LikedById == currentUserId).FirstOrDefault();

            this.Data.Likes.Delete(yourLike);

            context.SaveChanges();

            var workVotedFor = this.Data.Works.Find(id);

            return this.Content(workVotedFor.Likes.Count().ToString());
        }
    }
}