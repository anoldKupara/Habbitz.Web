using System.ComponentModel.DataAnnotations;

namespace Habbitz_Web.Models
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Purpose { get; set; }
        [Required]
        public string SourceOfFund { get; set; }
        [Required]
        public DateTime ProjectStartDate { get; set; }
        [Required]
        public DateTime ProjectEndDate { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public string Currency { get; set; }
    }
}
