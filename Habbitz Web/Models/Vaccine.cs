﻿namespace Habbitz_Web.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Purpose { get; set; }
        public string Alternative { get; set; }
        public DateTime ExpiryDate { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public string Currency { get; set; }
    }
}