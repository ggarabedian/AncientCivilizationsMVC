namespace AncientCivilizations.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Data.Repositories;
    using ViewModels.Home;

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
                                .ProjectTo<HomePageArticleViewModel>()
                                .ToList();

            if (data != null)
            {
                return View(data);
            }

            return View();
        }
    }
}