﻿namespace AncientCivilizations.Web.Models.Administration
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Base;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CategoryViewModel : AdministrationViewModel, IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}