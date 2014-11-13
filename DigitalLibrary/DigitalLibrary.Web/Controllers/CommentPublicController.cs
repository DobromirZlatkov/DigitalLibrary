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
<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/Controllers/CommentPublicController.cs
    using System;
    using System.Net;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using DigitalLibrary.Data;
    using DigitalLibrary.Models;
    using DigitalLibrary.Web.ViewModels.Comment;



    public class CommentPublicController : BaseController
=======
    public class CommentController : BaseController
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Controllers/CommentController.cs
    {
        public CommentPublicController(IDigitalLibraryData data)
            : base(data)
        {
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentPublicPostModel commentModel)
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

<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/Controllers/CommentPublicController.cs
                var viewModel = new CommentPublicViewModel { PostedBy = username, Content = commentModel.Content };

                return this.PartialView("_CommentPartial", viewModel);
=======
                var viewModel = new CommentViewModel { PostedBy = username, Content = commentModel.Content };
                return PartialView("_CommentPartial", viewModel);
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Controllers/CommentController.cs
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }
    }
}