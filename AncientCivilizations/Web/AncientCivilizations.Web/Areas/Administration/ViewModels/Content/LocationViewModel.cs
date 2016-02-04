namespace AncientCivilizations.Web.Areas.Administration.ViewModels.Content
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Base;
    using Data.Models;
    using Infrastructure.Mapping;

    public class LocationViewModel : AdministrationViewModel, IMapFrom<Location>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}