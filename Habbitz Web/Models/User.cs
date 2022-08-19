using System.ComponentModel.DataAnnotations;

namespace Habbitz_Web.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
              [Required]
        public string FirstName { get; set; }
              [Required]
        public string LastName { get; set; }
              [Required]
        public string PhoneNumber { get; set; }
              [Required]
        public string Email { get; set; }
              [Required]
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
