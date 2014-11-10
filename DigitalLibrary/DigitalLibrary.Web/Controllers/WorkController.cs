namespace DigitalLibrary.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.IO;

    using Microsoft.AspNet.Identity;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using DigitalLibrary.Data;
    using DigitalLibrary.Web.Models;
    using DigitalLibrary.Models;
    using DigitalLibrary.Logic;
    using System.ComponentModel.DataAnnotations;

    public class WorkController : BaseController
    {
        private const int PageSize = 5;
        private const int StartWorkYear = 1800;
        private static int currentYear = DateTime.Now.Year;


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



        private void LoadDataToViewBag()
        {
            IEnumerable<SelectListItem> authors = this.Data.Authors.All().Select(
               a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name });

            IEnumerable<SelectListItem> genres = this.Data.Genres.All().Select(
              a => new SelectListItem { Value = a.Id.ToString(), Text = a.GenreName });

            ViewBag.Year = new SelectList(Enumerable.Range(StartWorkYear, currentYear - StartWorkYear));

            ViewBag.Author = authors;

            ViewBag.Genre = genres;
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            LoadDataToViewBag();
            return View();
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();

            var viewModel = this.Data.Works.All().Where(x => x.Id == id)
                .Select(WorkDetailsViewModel.FromWork).FirstOrDefault();

            return View(viewModel);
        }

        public FileResult Download(int id)
        {
            var work = this.Data.Works.Find(id);

            if (!FileManager.CheckIfFileExists(work.ZipFileLink))
            {
                TempData["error"] = "File not found";
                Response.Redirect("/work/list");
                return null;
            }

            var fileBytes = FileManager.DownloadFile(work.ZipFileLink);

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, work.Title + ".zip");
        }

        [Authorize]
        public ActionResult Upload(WorkCreateViewModel createModel)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                var currentUser = this.Data.Users.Find(currentUserId);

                var genre = this.Data.Genres.Find(createModel.Genre);
                var author = this.Data.Authors.Find(createModel.Author);

                var workUploadPath = "UploadedFiles/" + genre.GenreName + "/" + author.Name + "/works/" + createModel.Title + "/";
                var zipFileLink = workUploadPath + createModel.Title + ".zip";
                var pictureFileLink = string.Empty;

                FileManager.CreateFolderIfDoesntExists("UploadedFiles/" + genre.GenreName);
                FileManager.CreateFolderIfDoesntExists("UploadedFiles/" + genre.GenreName + "/" + author.Name);
                FileManager.CreateFolderIfDoesntExists("UploadedFiles/" + genre.GenreName + "/" + author.Name + "/works/");
                FileManager.CreateFolderIfDoesntExists("UploadedFiles/" + genre.GenreName + "/" + author.Name + "/works/" + createModel.Title + "/");

                if (Request.Files.Count > 0 && Request.Files.Count < 3)
                {
                    var picutre = Request.Files[0];

                    var work = Request.Files[1];

                    if (FileManager.CheckIfFileIsPicture(picutre))
                    {
                        pictureFileLink = workUploadPath + createModel.Title + ".png";
                        FileManager.UploadFile(picutre, createModel.Title.ToLower(), workUploadPath);
                    }
                    else
                    {
   
                        LoadDataToViewBag();
                        return View("Create", createModel);
                    }
                    if (FileManager.CheckIfFileIsZipped(work))
                    {
                        FileManager.UploadFile(work, createModel.Title.ToLower(), workUploadPath);
                    }
                    else
                    {
                        LoadDataToViewBag();
                        return View("Create", createModel);
                    }
                }

                var newWork = new Work
                {
                    AuthorId = createModel.Author,
                    Description = createModel.Description,
                    GenreId = createModel.Genre,
                    UploadedById = currentUserId,
                    Year = createModel.Year,
                    Title = createModel.Title,
                    ZipFileLink = zipFileLink,
                    PictureLink = pictureFileLink
                };

                this.Data.Works.Add(newWork);
                this.Data.SaveChanges();

                var viewModel = this.Data.Works.All().Where(w => w.Id == newWork.Id).Select(WorkDetailsViewModel.FromWork).FirstOrDefault();

                TempData["success"] = "Uploaded successfully";
                return View("Details", viewModel);
            }

            LoadDataToViewBag();
            return View("Create", createModel);
        }

        public JsonResult GetWorks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllWorks().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWorkData(string text)
        {
            var result = this.Data.Works
                .All()
                .Where(w => w.Author.Name.ToLower().Contains(text.ToLower()) || w.Title.ToLower().Contains(text.ToLower()))
                .Select(s => new
                {
                    AuthorName = s.Author.Name,
                    Title = s.Title
                });

            var matchWords = new HashSet<object>();

            foreach (var item in result)
            {
                matchWords.Add(new
                {
                    MatchResult = item.AuthorName
                });

                matchWords.Add(new
                {
                    MatchResult = item.Title
                });
            }

            return Json(matchWords, JsonRequestBehavior.AllowGet);
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

            if (!string.IsNullOrEmpty(submitModel.MatchSearch))
            {
                var searchWord = submitModel.MatchSearch.ToLower();
                result = result.Where(x => x.Author.Name.ToLower().Contains(searchWord)
                    || x.Title.ToLower().Contains(searchWord)
                    || x.Description.ToLower().Contains(searchWord));
            }

            if (submitModel.GenreSearch != "All")
            {
                result = result.Where(x => x.Genre.GenreName == submitModel.GenreSearch);
            }

            if (submitModel.YearSearch != 0)
            {
                result = result.Where(x => x.Year == submitModel.YearSearch);
            }


            var endResult = result.Select(WorkListViewModel.FromWork);

            var test = endResult.ToList();

            return View(endResult);
        }

      
    }
}