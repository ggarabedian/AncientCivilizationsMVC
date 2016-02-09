namespace AncientCivilizations.Web.Models.Public
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Data.Models;
    using Infrastructure.Mapping;

    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        // TODO: Delete ?!
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [UIHint("DateTimeFormat")]
        public DateTime CreatedOn { get; set; }

        public string CreatorName { get; set; }

        public byte[] CreatorAvatar { get; set; }

        public string CreatorId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleViewModel>("")
                .ForMember(m => m.CreatorName, opt => opt.MapFrom(u => u.Creator.FullName));
            configuration.CreateMap<Article, ArticleViewModel>("")
                .ForMember(m => m.CreatorAvatar, opt => opt.MapFrom(u => u.Creator.Avatar));
            configuration.CreateMap<Article, ArticleViewModel>("")
                .ForMember(m => m.CreatorId, opt => opt.MapFrom(u => u.Creator.Id));
        }
    }
}