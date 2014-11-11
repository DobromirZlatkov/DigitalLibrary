namespace DigitalLibrary.Web.Controllers
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    using DigitalLibrary.Data;
    using DigitalLibrary.Web.Models;

    public class HomeController : BaseController
    {
        private const int NumberOfWorksPerPage = 4;

        public HomeController(ILibraryData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageData"] == null)
            {
                var topUsers = this.Data.Users.All()
                    .OrderByDescending(u => u.PositiveUploads)
                    .Select(HomePageUserViewModel.FromUser);

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
                    .Select(GenreViewModel.FromGenre)
                    .ToList();

                var mostPopularWorks = this.Data.Works.All()
                    .OrderByDescending(w => w.Likes.Count())
                    .Take(NumberOfWorksPerPage)
                    .Select(WorkListViewModel.FromWork);

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