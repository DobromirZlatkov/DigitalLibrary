namespace DigitalLibrary.Web.Controllers
{
    using System.Web.Mvc;

    using DigitalLibrary.Data;
    using DigitalLibrary.Models;

    public abstract class BaseController : Controller
    {
        public BaseController(ILibraryData data)
        {
            this.Data = data;
            this.IdentityManager = new IdentityManager();
        }

        protected ILibraryData Data { get; set; }

        protected IdentityManager IdentityManager { get; set; }
    }
}