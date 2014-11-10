using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Web.Models
{
    public class SubmitSearchModel
    {
        public string MatchSearch { get; set; }

        public string GenreSearch { get; set; }

        public int YearSearch { get; set; }
    }
}