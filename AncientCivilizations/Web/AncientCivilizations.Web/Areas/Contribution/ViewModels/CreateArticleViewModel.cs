namespace AncientCivilizations.Web.Areas.Contribution.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateArticleViewModel : IMapFrom<Article>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int CivilizationId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int? TimePeriodFrom { get; set; }

        public int? TimePeriodTo { get; set; }
    }
}