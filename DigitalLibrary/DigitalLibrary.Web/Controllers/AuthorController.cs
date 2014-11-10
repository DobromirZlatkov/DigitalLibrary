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
    public class AuthorController : BaseController
    {
        public AuthorController(ILibraryData data)
            : base(data)
        {
        }

        private IQueryable<AuthorListViewModel> GetAllAuthors()
        {
            var allAuthors = this.Data.Authors
                .All()
                .Select(AuthorListViewModel.FromAuthor);

            return allAuthors;
        }

       public ActionResult Create(AuthorCreateModel model)
        {
            var ifExists = this.Data.Authors.All().Any(a => a.Name.ToLower() == model.AuthorName.ToLower());

            if (!ifExists)
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
    }
}