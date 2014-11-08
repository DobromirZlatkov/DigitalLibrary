﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Web.Models
{
    public class HomePageStatisticsModel
    {
        public int NumberOfAuthors { get; set; }

        public int NumberOfUsers { get; set; }

        public int NumberOfGenres { get; set; }

        public int NumberOfWorks { get; set; }

    }
}