namespace DigitalLibrary.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.IO;
    using System.Collections.Generic;

    using DigitalLibrary.Models;
    using DigitalLibrary.Logic;
    

    public class GenreViewModel
    {
        public static Expression<Func<Genre, GenreViewModel>> FromGenre
        {
            get
            {
                return g => new GenreViewModel
                {
                    Id = g.Id,
                    GenreName = g.GenreName,
                    Works = g.Works.AsQueryable().Select(WorkListViewModel.FromWork).Take(4)
                };
            }
        }

        public int Id { get; set; }

        public string GenreName { get; set; }

        public IEnumerable<WorkListViewModel> Works { get; set; }
    }
}