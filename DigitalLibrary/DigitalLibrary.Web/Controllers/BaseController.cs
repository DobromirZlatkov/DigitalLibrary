namespace DigitalLibrary.Web.Controllers
{
    using System.Web.Mvc;

    using DigitalLibrary.Data;
    using DigitalLibrary.Models;
  

    public abstract class BaseController : Controller
    {
        public BaseController(IDigitalLibraryData data)
        {
            this.Data = data;
            this.IdentityManager = new IdentityManager();
        }

        protected IDigitalLibraryData Data { get; set; }

        protected IdentityManager IdentityManager { get; set; }

        protected User CurrentUser { get; set; }
    }
}