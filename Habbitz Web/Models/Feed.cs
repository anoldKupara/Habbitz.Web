namespace Habbitz_Web.Models
{
    public class Feed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Purpose { get; set; }
        public string Supplier { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
    }
}
