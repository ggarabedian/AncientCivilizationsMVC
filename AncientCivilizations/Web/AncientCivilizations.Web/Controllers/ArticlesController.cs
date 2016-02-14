namespace AncientCivilizations.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Data.Repositories;
    using Infrastructure.Mapping;
    using Models.Public;

    public class ArticlesController : BaseController
    {
        public ArticlesController(IAncientCivilizationsData data) 
            : base(data)
        {
        }

        public ActionResult All(string searchQuery)
        {
            var viewModel = this.Data.Articles.All();

            if (!String.IsNullOrEmpty(searchQuery))
            {
                viewModel = viewModel.Where(s => s.Title.Contains(searchQuery)
                                       || s.KeyWords.Contains(searchQuery));
            }

            return View(viewModel.To<ArticleViewModel>().ToList());
        }

        public ActionResult Detailed(int id)
        {
            var data = this.Data.Articles.GetById(id);
            var viewModel = Mapper.Map<ArticleViewModel>(data);

            return View(viewModel);
        }
    }
}