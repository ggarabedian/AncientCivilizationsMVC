namespace AncientCivilizations.Web.Models.Public
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Data.Models;
    using Infrastructure.Mapping;

    public class PicturesViewModel : IMapFrom<Picture>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        public string KeyWords { get; set; }

        public string ContributorId { get; set; }

        public string ContrubitorFullName { get; set; }

        public byte[] ContrubitorAvatar { get; set; }

        public string CategoryName { get; set; }

        [UIHint("DateTimeFormat")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Picture, PicturesViewModel>(string.Empty)
                .ForMember(m => m.ContributorId, opt => opt.MapFrom(u => u.Contributor.Id));
            configuration.CreateMap<Picture, PicturesViewModel>(string.Empty)
                .ForMember(m => m.ContrubitorFullName, opt => opt.MapFrom(u => u.Contributor.FullName));
            configuration.CreateMap<Picture, PicturesViewModel>(string.Empty)
                .ForMember(m => m.ContrubitorAvatar, opt => opt.MapFrom(u => u.Contributor.Avatar));
            configuration.CreateMap<Picture, PicturesViewModel>(string.Empty)
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name));
        }
    }
}
