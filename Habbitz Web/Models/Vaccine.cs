using System.ComponentModel.DataAnnotations;

namespace Habbitz_Web.Models
{
    public class Vaccine
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
        public string Alternative { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string Currency { get; set; }
    }
}
