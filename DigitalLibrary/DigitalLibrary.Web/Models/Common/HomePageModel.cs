namespace DigitalLibrary.Web.Models
{
    using System.Collections.Generic;

    public class HomePageModel
    {
        public IEnumerable<WorkListViewModel> MostPopularWorks { get; set; }

        public IEnumerable<GenreViewModel> GenreBooks { get; set; }

        public HomePageStatisticsModel Statistics { get; set; }

        public IEnumerable<HomePageUserViewModel> TopUsers { get; set; }
    }
}