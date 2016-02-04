namespace AncientCivilizations.Web.Areas.Administration.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

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
    }
}