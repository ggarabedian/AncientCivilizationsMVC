namespace AncientCivilizations.Web.Models.Public
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.Mapping;

    public class UserProfileViewModel : IMapFrom<User>, IMapTo<User>
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Real name")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Summary { get; set; }

        public string Biography { get; set; }

        public byte[] Avatar { get; set; }

        public string Photo { get; set; }

        public List<ArticleViewModel> Articles { get; set; }
    }
}