using DigitalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DigitalLibrary.Web.Models
{
    public class HomePageUserViewModel
    {
        public static Expression<Func<User, HomePageUserViewModel>> FromUser
        {
            get
            {
                return u => new HomePageUserViewModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                };
            }
        }

        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
