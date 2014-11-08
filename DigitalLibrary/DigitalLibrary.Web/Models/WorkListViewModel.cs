namespace DigitalLibrary.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.IO;

    using DigitalLibrary.Models;
    using DigitalLibrary.Logic;

    public class WorkListViewModel
    {
       // private static string test = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) ;

       // private static string RootDirectoryPath = test.Substring("file:\\".Length, test.Length - ("DigitalLibrary.Web".Length + 5 + "\\Digit".Length));

        //private static string fsdfasdfas = "fgdgsdfggdsf"; // test.Substring(0, test.Length - ("DigitalLibrary.Web".Length + 4));

        public static Expression<Func<Work, WorkListViewModel>> FromWork
        {
            get
            {
                return w => new WorkListViewModel
                {
                    Id = w.Id,
                    Title = w.Title,
                    Year = w.Year,
                    ZipFileLink = w.ZipFileLink,
                    PictureLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRzIGCGi1ahFM9tIRKLWe2Sv1AmIQAoPcE5k6UcoWjxxNv-BQc6", //RootDirectoryPath + w.PictureLink,
                    AuthorName = w.Author.Name,
                    AuthorId = w.AuthorId,
                    PositiveLikes = w.Likes.Count(l => l.IsPositive),
                    NegativeLikes = w.Likes.Count(l => !l.IsPositive),
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string ZipFileLink { get; set; }

        public string PictureLink { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId{ get; set; }

        private int PositiveLikes { get; set; }

        private int NegativeLikes { get; set; }

        public double LikeRate 
        {
            get
            {
                return PercentageCalculator.CalculatePersentage(this.PositiveLikes, this.NegativeLikes);
            } 
        }
    }
}