namespace AncientCivilizations.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Contracts;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IAuditInfo
    {
        private ICollection<Article> articles;
        private ICollection<Picture> pictures;
        private ICollection<Video> videos;

        public User()
        {
            this.articles = new HashSet<Article>();
            this.pictures = new HashSet<Picture>();
            this.videos = new HashSet<Video>();
        }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(800)]
        public string Summary { get; set; }

        [MaxLength(1000)]
        public string Biography { get; set; }

        public byte[] Avatar { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public string FacebookAccountLink { get; set; }

        public string TwitterAccountLink { get; set; }

        public string GoogleAccountLink { get; set; }

        public string LinkedInAccountLink { get; set; }

        [InverseProperty("Creator")]
        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }

        [InverseProperty("Contributor")]
        public virtual ICollection<Picture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }

        [InverseProperty("Contributor")]
        public virtual ICollection<Video> Videos
        {
            get { return this.videos; }
            set { this.videos = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
