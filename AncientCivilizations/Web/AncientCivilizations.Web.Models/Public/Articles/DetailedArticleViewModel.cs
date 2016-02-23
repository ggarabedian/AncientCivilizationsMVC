namespace AncientCivilizations.Web.Models.Public
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using AutoMapper;

    using Data.Models;
    using Infrastructure.Mapping;

    public class DetailedArticleViewModel : IMapFrom<Article>, IMapTo<Article>, IHaveCustomMappings
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [UIHint("DateTimeFormat")]
        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public string CreatorName { get; set; }

        public byte[] CreatorAvatar { get; set; }

        public string CreatorSummary { get; set; }

        public string HeaderImagePath { get; set; }

        public int CivilizationId { get; set; }

        public IEnumerable<ArticleViewModel> FiveSimilarArticles { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, DetailedArticleViewModel>(string.Empty)
                         .ForMember(m => m.CreatorName, opt => opt.MapFrom(u => u.Creator.FullName))
                         .ForMember(m => m.CreatorAvatar, opt => opt.MapFrom(u => u.Creator.Avatar))
                         .ForMember(m => m.CreatorId, opt => opt.MapFrom(u => u.Creator.Id))
                         .ForMember(m => m.CreatorSummary, opt => opt.MapFrom(u => u.Creator.Summary)); 
        }
    }
}
