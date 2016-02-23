namespace AncientCivilizations.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Contracts;

    public class Article : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(25000)]
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

        public string HeaderImagePath { get; set; }

        [Range(-4000, 2020)]
        public int? TimePeriodFrom { get; set; }

        [Range(-4000, 2020)]
        public int? TimePeriodTo { get; set; }

        [MaxLength(250)]
        public string KeyWords { get; set; }
    }
}
