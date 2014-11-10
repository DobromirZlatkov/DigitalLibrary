using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Web.Models
{
    public class HomePageModel
    {
        public IEnumerable<WorkListViewModel> MostPopularWorks { get; set; }

        public IEnumerable<GenreViewModel> GenreBooks { get; set; }

        public HomePageStatisticsModel Statistics { get; set; }

        public IEnumerable<HomePageUserViewModel> TopUsers { get; set; }
    }
}