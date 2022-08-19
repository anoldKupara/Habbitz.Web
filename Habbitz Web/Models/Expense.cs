using System.ComponentModel.DataAnnotations;

namespace Habbitz_Web.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public string Currency { get; set; }
    }
}
