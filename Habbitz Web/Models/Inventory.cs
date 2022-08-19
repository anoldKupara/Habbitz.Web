using System.ComponentModel.DataAnnotations;

namespace Habbitz_Web.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
              [Required]
        public string ItemName { get; set; }
              [Required]
        public string Purpose { get; set; }
              [Required]
        public int Quantity { get; set; }
              [Required]
        public float Amount { get; set; }
              [Required]
        public string Currency { get; set; }
              [Required]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
              [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
