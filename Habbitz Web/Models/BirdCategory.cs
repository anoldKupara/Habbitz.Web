using System.ComponentModel.DataAnnotations;

namespace Habbitz_Web.Models
{
    public class BirdCategory
    {
        [Key]
        public int Id { get; set; }
              [Required]
        public string Name { get; set; }
              [Required]
        public string Description { get; set; }
              [Required]
        public string Purpose { get; set; }
              [Required]
        public string Breed { get; set; }
    }
}
