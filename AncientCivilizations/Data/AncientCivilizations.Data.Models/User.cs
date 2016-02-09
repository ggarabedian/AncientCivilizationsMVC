namespace AncientCivilizations.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Contracts;

    public class User : IdentityUser, IAuditInfo
    {
        [Required]
        public string FullName { get; set; }

        public string Summary { get; set; }

        public string Biography { get; set; }

        public byte[] Avatar { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FacebookAccountLink { get; set; }
        public string TwitterAccountLink { get; set; }
        public string GoogleAccountLink { get; set; }
        public string LinkedInAccountLink { get; set; }
        //Social media accounts
        //Last modified from
    }
}
