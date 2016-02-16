namespace AncientCivilizations.Web.Models.Administration
{
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using Base;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : AdministrationViewModel, IMapFrom<User>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Summary { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Biography { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Contributed Articles")]
        public int ArticlesCount { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Contributed Pictures")]
        public int PicturesCount { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Contributed Videos")]
        public int VideosCount { get; set; }
    }
}