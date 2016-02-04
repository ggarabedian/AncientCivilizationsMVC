namespace AncientCivilizations.Web.Areas.Administration.ViewModels.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class AdministrationViewModel
    {
        [Required]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }
    }
}