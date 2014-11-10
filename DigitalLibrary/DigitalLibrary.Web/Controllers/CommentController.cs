using DigitalLibrary.Data;
using DigitalLibrary.Web.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DigitalLibrary.Models;

namespace DigitalLibrary.Web.Controllers
{
    public class CommentController : BaseController
    {
        public CommentController(ILibraryData data)
            : base(data)
        {
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(CommentPostModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment()
                {
                    PostedById = userId,
                    Content = commentModel.Content,
                    WorkId = commentModel.WorkId,
                    DatePosted = DateTime.Now
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { PostedBy = username, Content = commentModel.Content };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }
    }
}