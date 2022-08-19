using System.ComponentModel.DataAnnotations;

namespace Habbitz_Web.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
              [Required]
        public string ItemPurchased { get; set; }
              [Required]
        public int Quantity { get; set; }
              [Required]
        public float Price { get; set; }
              [Required]
        public string PaymentMethod { get; set; }
        public DateTime DateOfPurchase { get; set; } = DateTime.Now;
    }
}
