namespace AncientCivilizations.Web.Models.Public.Articles
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class AllArticlesViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentOrder { get; set; }

        public string CivilizationFilter { get; set; }

        public SelectList Civilizations { get; set; }
    }
}
