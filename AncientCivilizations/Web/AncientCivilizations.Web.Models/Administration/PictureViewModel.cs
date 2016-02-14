namespace AncientCivilizations.Web.Models.Administration
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using Base;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PictureViewModel : AdministrationViewModel, IMapFrom<Picture>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public string Url { get; set; }

        public string KeyWords { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ContributorId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ContributorFullName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CategoryName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CategoryId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Picture, PictureViewModel>("")
                .ForMember(m => m.ContributorId, opt => opt.MapFrom(u => u.Contributor.Id));
            configuration.CreateMap<Picture, PictureViewModel>("")
                .ForMember(m => m.ContributorFullName, opt => opt.MapFrom(u => u.Contributor.FullName));
            configuration.CreateMap<Picture, PictureViewModel>("")
                .ForMember(m => m.CategoryId, opt => opt.MapFrom(u => u.Category.Id));
            configuration.CreateMap<Picture, PictureViewModel>("")
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name));
        }
    }
}
