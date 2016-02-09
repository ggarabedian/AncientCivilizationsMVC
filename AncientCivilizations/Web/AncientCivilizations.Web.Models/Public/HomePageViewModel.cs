namespace AncientCivilizations.Web.Models.Public
{
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public ICollection<ArticleViewModel> Articles { get; set; }

        public ICollection<PicturesViewModel> Pictures { get; set; }

        public ICollection<ArticleViewModel> Videos { get; set; }
    }
}
