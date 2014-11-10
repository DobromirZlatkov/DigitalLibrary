using DigitalLibrary.Data;
using DigitalLibrary.Logic;
using DigitalLibrary.Web.Models;
using Kendo.Mvc;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalLibrary.Web.Controllers
{
    public class TrustedUserWorkController : BaseController
    {

        public TrustedUserWorkController(ILibraryData data)
            : base(data)
        {
        }

        public IQueryable<WorkListViewModel> GetAllUnApprovedWorks()
        {
            var unApprovedWorks = this.Data.Works
                .All()
                .Where(w => !w.IsApproved)
                .Select(WorkListViewModel.FromWork);

            return unApprovedWorks;
        }

        public ActionResult List([DataSourceRequest]DataSourceRequest request)
        {
            if (request.PageSize == 0)
            {
                request.PageSize = 5;
            }
          
            var data = GetAllUnApprovedWorks();
            
          
            //if (request.Page > 0)
            //{
            //    data = data.Skip((request.Page - 1) * request.PageSize);
            //}
            //data = data.Take(request.PageSize);

            return View(data);
        }

        public ActionResult Approove(int id)
        {
            var workToBeApprooved = this.Data.Works.Find(id);
            workToBeApprooved.IsApproved = true;
            this.Data.SaveChanges();
            return View("List");
        }

        public ActionResult Delete(int id)
        {
            var workToBeDeleted = this.Data.Works.Find(id);

            this.Data.Works.Delete(workToBeDeleted);

            var folders = workToBeDeleted.ZipFileLink.Split('/').ToList();
            folders.RemoveAt(folders.Count - 1);

            var filePath = string.Join("/",folders);


            FileManager.DeleteFile(filePath);

            this.Data.SaveChanges();
            return View("List");
        }
    }
}