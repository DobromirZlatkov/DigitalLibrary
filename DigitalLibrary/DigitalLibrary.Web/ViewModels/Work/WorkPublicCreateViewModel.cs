<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/ViewModels/Work/WorkPublicCreateViewModel.cs
﻿namespace DigitalLibrary.Web.ViewModels.Work
{
    using System.ComponentModel.DataAnnotations;

    public class WorkPublicCreateViewModel
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Web.Models
{
    public class WorkCreateViewModel
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Models/Work/WorkCreateViewModel.cs
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Use 5-100 characters")]
        public string Title { get; set; }

        [StringLength(400, MinimumLength = 5, ErrorMessage = "Use 5-400 characters")]
        public string Description { get; set; }

        [Required]
        [Range(1700, 2020, ErrorMessage = "Year has to be between 1700 and 2020")]
        public int Year { get; set; }

        [Required]
        public int Author { get; set; }

        [Required]
        public int Genre { get; set; }

    }
}