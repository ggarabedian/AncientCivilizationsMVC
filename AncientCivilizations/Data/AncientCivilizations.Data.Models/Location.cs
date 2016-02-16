namespace AncientCivilizations.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Location : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}