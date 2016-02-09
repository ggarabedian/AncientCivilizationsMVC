namespace AncientCivilizations.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Data.Repositories;
    using Models.Public;

    public class HomeController : BaseController
    {
        public HomeController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var data = this.Data.Articles
                                .All()
                                .Where(ar => ar.IsApproved)
                                .OrderByDescending(a => a.CreatedOn)
                                .Take(5)
                                .ProjectTo<ArticleViewModel>()
                                .ToList();

            if (data != null)
            {
                return View(data);
            }

            return View();
        }
    }
}