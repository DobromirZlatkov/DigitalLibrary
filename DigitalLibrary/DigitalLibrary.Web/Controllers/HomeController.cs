<<<<<<< HEAD
﻿using DigitalLibrary.Data;
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
=======
﻿namespace DigitalLibrary.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using System.Collections;

    using DigitalLibrary.Web.Models;
    using DigitalLibrary.Data;
 


>>>>>>> parent of 18492b8... Added role manager and did some role logic

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
<<<<<<< HEAD
            if (this.HttpContext.Cache["HomePageData"] == null)
            {
                var topUsers = this.Data.Users.All()
                  .OrderByDescending(u => u.PositiveUploads)
                  .Select(UserPublicListViewModel.FromUser);
=======
            //if (this.HttpContext.Cache["HomePageWorks"] == null)
            //{
>>>>>>> parent of 18492b8... Added role manager and did some role logic

            var topUsers = this.Data.Users.All()
                .OrderByDescending(u => u.PositiveUploads)
                .Select(HomePageUserViewModel.FromUser);

            var allAuthorsForStatistics = this.Data.Authors.All().Count();
            var allUsersForStatistics = this.Data.Users.All().Count();
            var allGenresForStatistics = this.Data.Genres.All().Count();
            var allWorksForStatistics = this.Data.Works.All().Count();

<<<<<<< HEAD
                var genres = this.Data.Genres
                    .All()
                    .Select(GenrePublicViewModel.FromGenre)
                    .ToList();

                var mostPopularWorks = this.Data.Works.All()
                    .Where(w => w.IsApproved)
                    .OrderByDescending(w => w.Likes.Count)
                    .Select(WorkPublicListViewModel.FromWork);
                    
=======
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
>>>>>>> parent of 18492b8... Added role manager and did some role logic

            var mostPopularWorks = this.Data.Works.All()
                .OrderByDescending(w => w.Likes.Count())
                .Take(NumberOfWorksPerPage)
                .Select(WorkListViewModel.FromWork);

<<<<<<< HEAD
                this.HttpContext.Cache.Add("HomePageData", homePageViewModel, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }
            return this.View(this.HttpContext.Cache["HomePageData"]);
=======
            HomePageModel homePageViewModel = new HomePageModel 
            {
                Statistics = statistics,
                GenreBooks = genres,
                MostPopularWorks = mostPopularWorks,
                TopUsers = topUsers
            };
            

            //var test = works.ToList();
            //    this.HttpContext.Cache.Add("HomePageWorks", works.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            //}
            //return View(this.HttpContext.Cache["HomePageWorks"]);
            return View(homePageViewModel);
>>>>>>> parent of 18492b8... Added role manager and did some role logic
        }

    }
}