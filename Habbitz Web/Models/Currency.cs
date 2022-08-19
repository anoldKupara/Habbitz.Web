using System.ComponentModel.DataAnnotations;

namespace Habbitz_Web.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CurrencyCode { get; set; }
        [Required]
        public int Rate { get; set; }
    }
}
