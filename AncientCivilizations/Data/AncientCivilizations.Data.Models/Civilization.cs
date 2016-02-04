namespace AncientCivilizations.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Civilization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}