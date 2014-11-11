namespace DigitalLibrary.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using DigitalLibrary.Data;
    using DigitalLibrary.Models;
    using DigitalLibrary.Web.Models;

    public class AuthorController : BaseController
    {
        public AuthorController(ILibraryData data)
            : base(data)
        {
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

                Response.Redirect("work/create");
                return this.View("create");
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        private IQueryable<AuthorListViewModel> GetAllAuthors()
        {
            var allAuthors = this.Data.Authors
                .All()
                .Select(AuthorListViewModel.FromAuthor);

            return allAuthors;
        }
    }
}