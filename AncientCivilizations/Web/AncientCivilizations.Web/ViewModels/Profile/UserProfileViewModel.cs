﻿namespace AncientCivilizations.Web.ViewModels.Profile
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Data.Models;
    using Infrastructure.Mapping;

    public class UserProfileViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Real name")]
        public string FullName { get; set; }

        public string Summary { get; set; }

        public string Biography { get; set; }

        public string Photo { get; set; }
    }
}