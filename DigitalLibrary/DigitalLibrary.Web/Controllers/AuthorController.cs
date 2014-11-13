using DigitalLibrary.Data;
using DigitalLibrary.Models;
using DigitalLibrary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DigitalLibrary.Web.Controllers
{
<<<<<<< HEAD
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using DigitalLibrary.Data;
    using DigitalLibrary.Models;
    using DigitalLibrary.Web.Models;
    using DigitalLibrary.Web.ViewModels.Author;

=======
>>>>>>> parent of 18492b8... Added role manager and did some role logic
    public class AuthorController : BaseController
    {
        public AuthorController(IDigitalLibraryData data)
            : base(data)
        {
        }

<<<<<<< HEAD
        public ActionResult Create(AuthorPublicCreateModel model)
=======
        private IQueryable<AuthorListViewModel> GetAllAuthors()
        {
            var allAuthors = this.Data.Authors
                .All()
                .Select(AuthorListViewModel.FromAuthor);

            return allAuthors;
        }

       public ActionResult Create(AuthorCreateModel model)
>>>>>>> parent of 18492b8... Added role manager and did some role logic
        {
            if (ModelState.IsValid)
            {
                var newAuthor = new Author
                {
                    Name = model.AuthorName
                };

                this.Data.Authors.Add(newAuthor);
                this.Data.SaveChanges();
                return View("")//to return authordropdown list view

            }
           
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }
<<<<<<< HEAD

        private IQueryable<AuthorPublicListViewModel> GetAllAuthors()
        {
            var allAuthors = this.Data.Authors
                .All()
                .Where(a => !a.IsDeleted)
                .Select(AuthorPublicListViewModel.FromAuthor);

            return allAuthors;
        }
=======
>>>>>>> parent of 18492b8... Added role manager and did some role logic
    }
}