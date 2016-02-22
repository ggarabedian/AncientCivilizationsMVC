namespace AncientCivilizations.Web.Models.Contribution
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using Data.Models;
    using Infrastructure.Mapping;

    public class ContributeArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [UIHint("ArticleTitle")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [UIHint("ArticleContent")]
        public string Content { get; set; }

        [Required]
        [UIHint("LocationsDropdown")]
        public int LocationId { get; set; }

        [Required]
        [UIHint("CivilizationsDropdown")]
        public int CivilizationId { get; set; }
        
        [Required]
        [UIHint("CategoriesDropdown")]
        public int CategoryId { get; set; }

        public int? TimePeriodFrom { get; set; }

        public int? TimePeriodTo { get; set; }

        public string HeaderImagePath { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string LastEditorId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, ContributeArticleViewModel>(string.Empty)
                .ForMember(m => m.LastEditorId, opt => opt.MapFrom(u => u.LastEditor.Id));
        }
    }
}