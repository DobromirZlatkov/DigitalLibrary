namespace DigitalLibrary.Web.Controllers
{
    using System.Web.Mvc;

    using DigitalLibrary.Data;
    using DigitalLibrary.Models;
  

    public abstract class BaseController : Controller
    {
<<<<<<< HEAD
        public BaseController(IDigitalLibraryData data)
=======
        protected ILibraryData Data { get; set; }

        public BaseController(ILibraryData data)
>>>>>>> parent of 18492b8... Added role manager and did some role logic
        {
            this.Data = data;
        }
<<<<<<< HEAD

        protected IDigitalLibraryData Data { get; set; }

        protected IdentityManager IdentityManager { get; set; }

        protected User CurrentUser { get; set; }
=======
>>>>>>> parent of 18492b8... Added role manager and did some role logic
    }
}