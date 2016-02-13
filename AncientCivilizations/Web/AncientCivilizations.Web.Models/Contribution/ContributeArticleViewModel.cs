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
        public string Title { get; set; }

        [AllowHtml]
        [Required]
        public string Content { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int CivilizationId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string CreatorId { get; set; }

        public int? TimePeriodFrom { get; set; }

        public int? TimePeriodTo { get; set; }

        public string HeaderImagePath { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string LastEditorId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, ContributeArticleViewModel>("")
                .ForMember(m => m.LastEditorId, opt => opt.MapFrom(u => u.LastEditor.Id));
        }
    }
}