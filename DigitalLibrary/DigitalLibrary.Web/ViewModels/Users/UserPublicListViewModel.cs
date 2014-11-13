<<<<<<< HEAD:DigitalLibrary/DigitalLibrary.Web/ViewModels/Users/UserPublicListViewModel.cs
﻿namespace DigitalLibrary.Web.ViewModels.Users
{
    using System;
    using System.Linq.Expressions;

    using DigitalLibrary.Models;

    public class UserPublicListViewModel
=======
﻿using DigitalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DigitalLibrary.Web.Models
{
    public class HomePageUserViewModel
>>>>>>> parent of 18492b8... Added role manager and did some role logic:DigitalLibrary/DigitalLibrary.Web/Models/User/HomePageUserViewModel.cs
    {
        public static Expression<Func<User, UserPublicListViewModel>> FromUser
        {
            get
            {
                return u => new UserPublicListViewModel
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
