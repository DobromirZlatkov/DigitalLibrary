namespace DigitalLibrary.Web.Models
{
    using System;
    using System.Linq.Expressions;

    using DigitalLibrary.Models;

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
