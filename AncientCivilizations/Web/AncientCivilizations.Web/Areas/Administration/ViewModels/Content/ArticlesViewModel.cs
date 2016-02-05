namespace AncientCivilizations.Web.Areas.Administration.ViewModels.Content
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Base;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ArticlesViewModel : AdministrationViewModel, IMapFrom<Article>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}