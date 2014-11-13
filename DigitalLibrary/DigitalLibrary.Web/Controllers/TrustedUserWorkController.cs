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
<<<<<<< HEAD
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using DigitalLibrary.Data;
    using DigitalLibrary.Web.Models;
    using DigitalLibrary.Web.ViewModels.Work;
    using DigitalLibrary.Data.Logic;

    // [Authorize(Roles = "trusted")]
    public class TrustedUserWorkController : BaseController
    {
        private const int TrustedRoleNeededRating = 70;
        private const int MinimumPositiveUploadsToBecomeTrusted = 3;

        public TrustedUserWorkController(IDigitalLibraryData data)
=======
    public class TrustedUserWorkController : BaseController
    {

        public TrustedUserWorkController(ILibraryData data)
>>>>>>> parent of 18492b8... Added role manager and did some role logic
            : base(data)
        {
        }

<<<<<<< HEAD
        public ActionResult List()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
=======
        public IQueryable<WorkListViewModel> GetAllUnApprovedWorks()
        {
            var unApprovedWorks = this.Data.Works
                .All()
                .Where(w => !w.IsApproved)
                .Select(WorkListViewModel.FromWork);

            return unApprovedWorks;
        }

        public ActionResult List([DataSourceRequest]DataSourceRequest request)
>>>>>>> parent of 18492b8... Added role manager and did some role logic
        {
            if (request.PageSize == 0)
            {
                request.PageSize = 5;
            }
<<<<<<< HEAD

            var data = this.GetAllUnApprovedWorks()
                .ToDataSourceResult(request);

            return this.Json(data);
            //return this.View(data);
=======
          
            var data = GetAllUnApprovedWorks();
            
          
            //if (request.Page > 0)
            //{
            //    data = data.Skip((request.Page - 1) * request.PageSize);
            //}
            //data = data.Take(request.PageSize);

            return View(data);
>>>>>>> parent of 18492b8... Added role manager and did some role logic
        }

        public ActionResult Approove(int id)
        {
<<<<<<< HEAD
            var workToBeApprooved = this.Data.Works.GetById(id);
            var uploadedBy = workToBeApprooved.UploadedBy;

            uploadedBy.PositiveUploads++;
=======
            var workToBeApprooved = this.Data.Works.Find(id);
>>>>>>> parent of 18492b8... Added role manager and did some role logic
            workToBeApprooved.IsApproved = true;
            this.Data.SaveChanges();
<<<<<<< HEAD

            if (uploadedBy.Rating > TrustedRoleNeededRating && uploadedBy.PositiveUploads >= MinimumPositiveUploadsToBecomeTrusted)
            {
                this.IdentityManager.AddUserToRole(uploadedBy.Id, "trusted");
            }
            Response.Redirect("~/TrustedUserWork/List");
            return this.View("List");
=======
            return View("List");
>>>>>>> parent of 18492b8... Added role manager and did some role logic
        }

        public ActionResult Delete([DataSourceRequest]DataSourceRequest request, WorkPublicListViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var workToBeDeleted = this.Data.Works.GetById(model.Id);

<<<<<<< HEAD
                var uploadedBy = workToBeDeleted.UploadedBy;
                uploadedBy.NegativeUploads++;

                this.Data.Works.Delete(workToBeDeleted);
                this.Data.SaveChanges();

                var folders = workToBeDeleted.ZipFileLink.Split('/').ToList();

                folders.RemoveAt(folders.Count - 1);
=======
            this.Data.Works.Delete(workToBeDeleted);

            var folders = workToBeDeleted.ZipFileLink.Split('/').ToList();
            folders.RemoveAt(folders.Count - 1);

            var filePath = string.Join("/",folders);

>>>>>>> parent of 18492b8... Added role manager and did some role logic

                var filePath = string.Join("/", folders);

<<<<<<< HEAD
                FileManager.DeleteFile(filePath);

                if (uploadedBy.Rating < TrustedRoleNeededRating)
                {
                    this.IdentityManager.ClearUserRoles(uploadedBy.Id, "trusted");
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private IQueryable<WorkPublicListViewModel> GetAllUnApprovedWorks()
        {
            var unApprovedWorks = this.Data.Works
                .All()
                .Where(w => !w.IsApproved)
                .Select(WorkPublicListViewModel.FromWork);

            return unApprovedWorks;
=======
            this.Data.SaveChanges();
            return View("List");
>>>>>>> parent of 18492b8... Added role manager and did some role logic
        }
    }
}