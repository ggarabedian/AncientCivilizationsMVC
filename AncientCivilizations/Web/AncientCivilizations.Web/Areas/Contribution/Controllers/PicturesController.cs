namespace AncientCivilizations.Web.Areas.Contribution.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    using AutoMapper;

    using Base;
    using Common.Constants;
    using Common.Extensions;
    using Data.Models;
    using Data.Repositories;
    using Models.Contribution;

    public class PicturesController : ContributionsController
    {
        public PicturesController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ContributePictureViewModel model, IEnumerable<HttpPostedFileBase> images)
        {
            if (model != null || images.Count() != 0)
            {
                model.Url = ImageEditor.SaveImageToServer(images, User.Identity.GetUserId());
                model.ContributorId = this.User.Identity.GetUserId();

                if (ModelState.IsValid)
                {
                    var dbModel = Mapper.Map<Picture>(model);
                    this.Data.Pictures.Add(dbModel);
                    this.Data.SaveChanges();
                    return this.RedirectToAction(Actions.Index, Controllers.Home, new { area = Areas.Contribution });
                }
            }

            return View(model);
        }
    }
}