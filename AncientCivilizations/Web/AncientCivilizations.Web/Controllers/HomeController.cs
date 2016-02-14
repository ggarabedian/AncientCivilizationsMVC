namespace AncientCivilizations.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Public;

    public class HomeController : BaseController
    {
        public HomeController(IAncientCivilizationsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var articles = this.Data.Articles
                                .All()
                                .Where(ar => ar.IsApproved)
                                .OrderByDescending(a => a.CreatedOn)
                                .Take(5)
                                .To<ArticleViewModel>()
                                .ToList();

            var pictures = this.Data.Pictures
                               .All()
                               .OrderByDescending(p => p.CreatedOn)
                               .Take(3)
                               .To<PicturesViewModel>()
                               .ToList();

            var data = new AllContentViewModel() { Articles = articles, Pictures = pictures };

            if (data != null)
            {
                return View(data);
            }

            return View();
        }
    }
}