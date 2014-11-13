using DigitalLibrary.Data;
using DigitalLibrary.Web.ViewModels.Genre;
using DigitalLibrary.Web.ViewModels.Home;
using DigitalLibrary.Web.ViewModels.Users;
using DigitalLibrary.Web.ViewModels.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace DigitalLibrary.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IDigitalLibraryData data)
        : base(data)
        {

        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageData"] == null)
            {
                var topUsers = this.Data.Users.All()
                  .OrderByDescending(u => u.PositiveUploads)
                  .Select(UserPublicListViewModel.FromUser);

                var allAuthorsForStatistics = this.Data.Authors.All().Count();
                var allUsersForStatistics = this.Data.Users.All().Count();
                var allGenresForStatistics = this.Data.Genres.All().Count();
                var allWorksForStatistics = this.Data.Works.All().Count();

                var statistics = new HomePageStatisticsModel
                {
                    NumberOfAuthors = allAuthorsForStatistics,
                    NumberOfGenres = allGenresForStatistics,
                    NumberOfUsers = allUsersForStatistics,
                    NumberOfWorks = allWorksForStatistics
                };

                var genres = this.Data.Genres
                    .All()
                    .Select(GenrePublicViewModel.FromGenre)
                    .ToList();

                var mostPopularWorks = this.Data.Works.All()
                    .Where(w => w.IsApproved)
                    .OrderByDescending(w => w.Likes.Count)
                    .Select(WorkPublicListViewModel.FromWork);
                    

                HomePageModel homePageViewModel = new HomePageModel
                {
                    Statistics = statistics,
                    GenreBooks = genres,
                    MostPopularWorks = mostPopularWorks,
                    TopUsers = topUsers
                };

                this.HttpContext.Cache.Add("HomePageData", homePageViewModel, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }
            return this.View(this.HttpContext.Cache["HomePageData"]);
        }
    }
}