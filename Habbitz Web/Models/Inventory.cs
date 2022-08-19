namespace Habbitz_Web.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Purpose { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; }
    }
}
