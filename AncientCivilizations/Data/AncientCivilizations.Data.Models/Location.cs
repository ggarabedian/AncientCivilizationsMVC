namespace AncientCivilizations.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Location : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}