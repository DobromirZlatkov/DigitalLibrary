using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Web.Models
{
    public class WorkCreateViewModel
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