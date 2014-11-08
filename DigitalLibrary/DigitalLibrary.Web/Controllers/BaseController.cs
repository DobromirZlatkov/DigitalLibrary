namespace DigitalLibrary.Web.Controllers
{
    using System.Web.Mvc;

    using DigitalLibrary.Data;
    using DigitalLibrary.Models;

    public abstract class BaseController : Controller
    {
        protected ILibraryData Data { get; set; }

        public BaseController(ILibraryData data)
        {
            this.Data = data;
        }

    }
}