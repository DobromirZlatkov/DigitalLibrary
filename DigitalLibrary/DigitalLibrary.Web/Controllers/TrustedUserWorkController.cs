namespace DigitalLibrary.Web.Controllers
{
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
            : base(data)
        {
        }

        public ActionResult List()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            if (request.PageSize == 0)
            {
                request.PageSize = 5;
            }

            var data = this.GetAllUnApprovedWorks()
                .ToDataSourceResult(request);

            return this.Json(data);
            //return this.View(data);
        }

        public ActionResult Approove(int id)
        {
            var workToBeApprooved = this.Data.Works.GetById(id);
            var uploadedBy = workToBeApprooved.UploadedBy;

            uploadedBy.PositiveUploads++;
            workToBeApprooved.IsApproved = true;

            this.Data.SaveChanges();

            if (uploadedBy.Rating > TrustedRoleNeededRating && uploadedBy.PositiveUploads >= MinimumPositiveUploadsToBecomeTrusted)
            {
                this.IdentityManager.AddUserToRole(uploadedBy.Id, "trusted");
            }
            Response.Redirect("~/TrustedUserWork/List");
            return this.View("List");
        }

        public ActionResult Delete([DataSourceRequest]DataSourceRequest request, WorkPublicListViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var workToBeDeleted = this.Data.Works.GetById(model.Id);

                var uploadedBy = workToBeDeleted.UploadedBy;
                uploadedBy.NegativeUploads++;

                this.Data.Works.Delete(workToBeDeleted);
                this.Data.SaveChanges();

                var folders = workToBeDeleted.ZipFileLink.Split('/').ToList();

                folders.RemoveAt(folders.Count - 1);

                var filePath = string.Join("/", folders);

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
        }
    }
}