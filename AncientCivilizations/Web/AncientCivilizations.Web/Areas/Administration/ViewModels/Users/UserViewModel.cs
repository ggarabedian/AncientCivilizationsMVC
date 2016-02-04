namespace AncientCivilizations.Web.Areas.Administration.ViewModels.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Registered On")]
        public DateTime RegisteredOn { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }

        public string Roles { get; set; }
    }
}