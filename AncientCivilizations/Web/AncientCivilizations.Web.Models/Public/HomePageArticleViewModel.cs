﻿namespace AncientCivilizations.Web.Models.Public
{
    using System;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class HomePageArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorName { get; set; }

        public byte[] CreatorAvatar { get; set; }

        public string CreatorId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Article, HomePageArticleViewModel>("")
                .ForMember(m => m.CreatorName, opt => opt.MapFrom(u => u.Creator.FullName));
            configuration.CreateMap<Article, HomePageArticleViewModel>("")
                .ForMember(m => m.CreatorAvatar, opt => opt.MapFrom(u => u.Creator.Avatar));
            configuration.CreateMap<Article, HomePageArticleViewModel>("")
                .ForMember(m => m.CreatorId, opt => opt.MapFrom(u => u.Creator.Id));
        }
    }
}