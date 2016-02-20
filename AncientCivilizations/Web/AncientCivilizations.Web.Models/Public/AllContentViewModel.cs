namespace AncientCivilizations.Web.Models.Public
{
    using System.Collections.Generic;

    public class AllContentViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }

        public IEnumerable<PicturesViewModel> Pictures { get; set; }

        //// public IEnumerable<ArticleViewModel> Videos { get; set; }
    }
}
