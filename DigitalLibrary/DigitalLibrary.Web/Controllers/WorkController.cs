namespace DigitalLibrary.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using DigitalLibrary.Data;
    using DigitalLibrary.Web.Models;

    public class WorkController : BaseController
    {
        private const int PageSize = 5;

        public WorkController(ILibraryData data)
            : base(data)
        {
        }

        // GET: Work
        private IQueryable<WorkListViewModel> GetAllWorks()
        {
            var allWorks = this.Data.Works
                .All()
                .Select(WorkListViewModel.FromWork);

            return allWorks;
        }

        public ActionResult List()
        {
            return View();
        }

        public JsonResult GetWorks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllWorks().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWorkAuthorData(string text)
        {
            var result = this.Data.Works
                .All()
                .Where(w => w.Author.Name.ToLower().Contains(text.ToLower()))
                .Select(s => new
                {
                    AuthorName = s.Author.Name
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWorkGenreData()
        {
            var genres = this.Data.Genres
                .All()
                .Select(x => new
                {
                    Genre = x.GenreName
                });

            return Json(genres, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(SubmitSearchModel submitModel)
        {
            var result = this.Data.Works.All();

            if (!string.IsNullOrEmpty(submitModel.AuthorSearch))
            {
                result = result.Where(x => x.Author.Name.ToLower().Contains(submitModel.AuthorSearch.ToLower()));
            }

            //if (submitModel.GenreSearch != "All")
            //{
            //    result = result.Where(x => x.Genre.GenreName == submitModel.GenreSearch);
            //}

            //if (submitModel.YearSearch != 0)
            //{
            //    result = result.Where(x => x.Year == submitModel.YearSearch);
            //}

            var endResult = result.Select(WorkListViewModel.FromWork);

            var test = endResult.ToList();

            return View(endResult);
        }
        // Works/List/4
        //public ActionResult List(int? id)
        //{
        //    var pageNumber = id.GetValueOrDefault(1);
        //    var viewModel = GetAllWorks()
        //        .Skip((pageNumber - 1) * PageSize)
        //        .Take(PageSize);

        //    ViewBag.Pages = Math.Ceiling((double)GetAllWorks().Count() / PageSize);

        //    return View(viewModel);
    }

}