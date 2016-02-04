namespace AncientCivilizations.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Contracts;

    public class Article : AuditInfo
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
        public int CivilizationId { get; set; }

        [ForeignKey("CivilizationId")]
        public virtual Civilization Civilization { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }

        public bool IsApproved { get; set; }

        public string ApproverId { get; set; }

        [ForeignKey("ApproverId")]
        public virtual User Approver { get; set; }

        public string LastEditorId { get; set; }

        [ForeignKey("LastEditorId")]
        public virtual User LastEditor { get; set; }

        public int? TimePeriodFrom { get; set; }

        public int? TimePeriodTo { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Video> Videos { get; set; }
    }
}
