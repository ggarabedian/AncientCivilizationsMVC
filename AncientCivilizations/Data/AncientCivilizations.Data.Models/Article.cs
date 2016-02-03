namespace AncientCivilizations.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article
    {
        public Article()
        {
            this.Images = new HashSet<Image>();
            this.Videos = new HashSet<Video>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Video> Videos { get; set; }

        // AprovedBy //LastEditedBy //LastEditedDate
    }
}
