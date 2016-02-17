namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Base;
    using Common.GlobalConstants;
    using Data.Repositories;
    using Models.Contribution;
    using Services.Contracts;

    public class PicturesController : ContributionsController
    {
        private IPictureServices pictureServices;

        public PicturesController(IAncientCivilizationsData data, IPictureServices pictureServices)
            : base(data)
        {
            this.pictureServices = pictureServices;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ContributePictureViewModel model, IEnumerable<HttpPostedFileBase> images)
        {
            if (model != null || images != null)
            {
                this.pictureServices.Add(model, images, this.User.Identity.GetUserId());
                return this.RedirectToAction(Actions.Index, Controllers.Home, new { area = Areas.Contribution });
            }

            return View(model);
        }
    }
}