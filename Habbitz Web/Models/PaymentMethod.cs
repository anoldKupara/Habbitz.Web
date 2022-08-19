using System.ComponentModel.DataAnnotations;

namespace Habbitz_Web.Models
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
