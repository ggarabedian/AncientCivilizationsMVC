﻿namespace AncientCivilizations.Web.Models.Contribution
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Data.Models;
    using Infrastructure.Mapping;

    public class ContributePictureViewModel : IMapFrom<Picture>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public string Url { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string ContributorId { get; set; }

        [MaxLength(250)]
        public string KeyWords { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Picture, ContributePictureViewModel>(string.Empty)
                .ForMember(m => m.ContributorId, opt => opt.MapFrom(u => u.Contributor.Id))
                .ForMember(m => m.CategoryId, opt => opt.MapFrom(u => u.Category.Id));
        }
    }
}
