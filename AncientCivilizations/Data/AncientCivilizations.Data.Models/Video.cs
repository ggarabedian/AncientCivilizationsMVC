namespace AncientCivilizations.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(300)]
        public string Url { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public string ContributorId { get; set; }

        [ForeignKey("ContributorId")]
        public virtual User Contributor { get; set; }

        [MaxLength(200)]
        public string KeyWords { get; set; }
    }
}