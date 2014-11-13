using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkPublicController.cs
    using DigitalLibrary.Models;
    using DigitalLibrary.Web.Models;
    using DigitalLibrary.Web.ViewModels.Work;
    using DigitalLibrary.Data.Logic;
    using DigitalLibrary.Web.ViewModels.Common;
=======
    using DigitalLibrary.Web.Models;
    using DigitalLibrary.Models;
    using DigitalLibrary.Logic;
    using System.ComponentModel.DataAnnotations;
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkController.cs

    public class WorkPublicController : BaseController
    {
        private const int PageSize = 5;
        private const int StartWorkYear = 1800;
        private static int currentYear = DateTime.Now.Year;

<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkPublicController.cs
        public WorkPublicController(IDigitalLibraryData data)
=======

        public WorkController(ILibraryData data)
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkController.cs
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
                .Select(WorkPublicDetailsViewModel.FromWork).FirstOrDefault();

            return View(viewModel);
        }

        public FileResult Download(int id)
        {
            var work = this.Data.Works.GetById(id);

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
<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkPublicController.cs
        public ActionResult Upload(WorkPublicCreateViewModel createModel, ICollection<HttpPostedFileBase> files)
=======
        public ActionResult Upload(WorkCreateViewModel createModel)
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkController.cs
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkPublicController.cs
                var currentUser = this.Data.Users.GetById(currentUserId);
                var genre = this.Data.Genres.All().Where(g => g.GenreName == createModel.Genre).FirstOrDefault();
                var author = this.Data.Authors.All().Where(g => g.Name == createModel.Author).FirstOrDefault();
=======
                var currentUser = this.Data.Users.Find(currentUserId);
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkController.cs

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

<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkPublicController.cs
                var viewModel = this.Data.Works.All()
                    .Where(w => w.Id == newWork.Id)
                    .Select(WorkPublicDetailsViewModel.FromWork)
                    .FirstOrDefault();
=======
                var viewModel = this.Data.Works.All().Where(w => w.Id == newWork.Id).Select(WorkDetailsViewModel.FromWork).FirstOrDefault();
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkController.cs

                TempData["success"] = "Uploaded successfully";
                return View("Details", viewModel);
            }

<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkPublicController.cs
         //   this.LoadDataToViewBag();
            return this.View("Create", createModel);
=======
            LoadDataToViewBag();
            return View("Create", createModel);
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkController.cs
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

<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkPublicController.cs
            var endResult = result.Select(WorkPublicListViewModel.FromWork);

            var test = endResult.ToList();

            return this.View(endResult);
        }

        private void UploadFile(HttpPostedFileBase file, string genre, string author, string title)
        {
            var workUploadPath = "UploadedFiles/" + genre + "/" + author + "/works/" + title + "/";
            var zipFileLink = workUploadPath + title + ".zip";
            var pictureFileLink = string.Empty;

            FileManager.CreateFolderIfDoesntExists("UploadedFiles/" + genre);
            FileManager.CreateFolderIfDoesntExists("UploadedFiles/" + genre + "/" + author);
            FileManager.CreateFolderIfDoesntExists("UploadedFiles/" + genre + "/" + author + "/works/");
            FileManager.CreateFolderIfDoesntExists("UploadedFiles/" + genre + "/" + author + "/works/" + title + "/");

            if (Request.Files.Count > 0 && Request.Files.Count < 3)
            {
                if (FileManager.CheckIfFileIsPicture(file))
                {
                    FileManager.UploadFile(file, title.ToLower(), workUploadPath);
                }
                else if (FileManager.CheckIfFileIsZipped(file))
                {
                    FileManager.UploadFile(file, title.ToLower(), workUploadPath);
                }
                else
                {
                    throw new ValidationException("Files are not in correct format");
                }
            }
        }

        private void LoadDataToViewBag()
        {
            IEnumerable<SelectListItem> authors = this.Data.Authors.All().Select(
               a => new SelectListItem { Value = a.Name, Text = a.Name });

            IEnumerable<SelectListItem> genres = this.Data.Genres.All().Select(
              a => new SelectListItem { Value = a.GenreName, Text = a.GenreName });

            this.ViewBag.Year = new SelectList(Enumerable.Range(StartWorkYear, currentYear - StartWorkYear), Enumerable.Range(StartWorkYear, currentYear - StartWorkYear));

            this.ViewBag.Author = authors;

            this.ViewData["Genre"] = genres;
        }

        private IQueryable<WorkPublicListViewModel> GetAllWorks()
        {
            var allWorks = this.Data.Works
                .All()
                .Where(w => w.IsApproved)
                .Select(WorkPublicListViewModel.FromWork);

            return allWorks;
        }
=======

            var endResult = result.Select(WorkListViewModel.FromWork);

            var test = endResult.ToList();

            return View(endResult);
        }

      
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Controllers/WorkController.cs
    }
}