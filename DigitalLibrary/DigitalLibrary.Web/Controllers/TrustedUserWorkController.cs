namespace DigitalLibrary.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;

    using DigitalLibrary.Data;
    using DigitalLibrary.Logic;
    using DigitalLibrary.Web.Models;

    [Authorize(Roles = "trusted")]
    public class TrustedUserWorkController : BaseController
    {
        private const int TrustedRoleNeededRating = 70;
        private const int MinimumPositiveUploadsToBecomeTrusted = 3;
       
        public TrustedUserWorkController(ILibraryData data)
            : base(data)
        {
        }

        public ActionResult List([DataSourceRequest]DataSourceRequest request)
        {
            if (request.PageSize == 0)
            {
                request.PageSize = 5;
            }

            var data = this.GetAllUnApprovedWorks();

            return this.View(data);
        }

        public ActionResult Approove(int id)
        {
            var workToBeApprooved = this.Data.Works.Find(id);
            var uploadedBy = workToBeApprooved.UploadedBy;

            uploadedBy.PositiveUploads++;
            workToBeApprooved.IsApproved = true;

            this.Data.SaveChanges();

            if (uploadedBy.Rating > TrustedRoleNeededRating && uploadedBy.PositiveUploads >= MinimumPositiveUploadsToBecomeTrusted)
            {
                this.IdentityManager.AddUserToRole(uploadedBy.Id, "trusted");
            }

            return this.View("List");
        }

        public ActionResult Delete(int id)
        {
            var workToBeDeleted = this.Data.Works.Find(id);

            var uploadedBy = workToBeDeleted.UploadedBy;
            uploadedBy.NegativeUploads++;
           
            this.Data.Works.Delete(workToBeDeleted);

            var folders = workToBeDeleted.ZipFileLink.Split('/').ToList();

            folders.RemoveAt(folders.Count - 1);

            var filePath = string.Join("/", folders);

            FileManager.DeleteFile(filePath);

            this.Data.SaveChanges();

            if (uploadedBy.Rating < TrustedRoleNeededRating)
            {
                this.IdentityManager.ClearUserRoles(uploadedBy.Id, "trusted");
            }

            return this.View("List");
        }

        private IQueryable<WorkListViewModel> GetAllUnApprovedWorks()
        {
            var unApprovedWorks = this.Data.Works
                .All()
                .Where(w => !w.IsApproved)
                .Select(WorkListViewModel.FromWork);

            return unApprovedWorks;
        }
    }
}