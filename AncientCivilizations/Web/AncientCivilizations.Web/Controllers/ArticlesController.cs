﻿namespace AncientCivilizations.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Data.Repositories;
    using Models.Public;

    public class ArticlesController : BaseController
    {
        public ArticlesController(IAncientCivilizationsData data) 
            : base(data)
        {
        }

        public ActionResult DetailedView(int id)
        {
            var data = this.Data.Articles.GetById(id);
            var viewModel = Mapper.Map<ArticleDetailedViewModel>(data);
            return View(viewModel);
        }
    }
}