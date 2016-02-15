namespace AncientCivilizations.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Common.Extensions;
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
            var data = this.Data.Articles.All();

            if (!String.IsNullOrEmpty(searchQuery))
            {
                data = data.Where(s => s.Title.Contains(searchQuery)
                                       || s.KeyWords.Contains(searchQuery));
            }

            var viewModel = data.To<ArticleViewModel>().ToList();

            foreach (var item in viewModel)
            {
                item.Content = Sanitizer.Sanitize(item.Content);
            }            

            return View(viewModel);
        }

        public ActionResult Detailed(int id)
        {
            var data = this.Data.Articles.GetById(id);
            var viewModel = Mapper.Map<ArticleViewModel>(data);
            //viewModel.Content = Sanitizer.Sanitize(viewModel.Content);

            return View(viewModel);
        }
    }
}