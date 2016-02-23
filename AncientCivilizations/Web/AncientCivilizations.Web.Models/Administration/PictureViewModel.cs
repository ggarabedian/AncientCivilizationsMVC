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

        [Display(Name = "Key Words")]
        public string KeyWords { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ContributorId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ContributorFullName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CategoryName { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Picture, PictureViewModel>(string.Empty)
                .ForMember(m => m.ContributorId, opt => opt.MapFrom(u => u.Contributor.Id))
                .ForMember(m => m.ContributorFullName, opt => opt.MapFrom(u => u.Contributor.FullName))
                .ForMember(m => m.CategoryId, opt => opt.MapFrom(u => u.Category.Id))
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name));
        }
    }
}
