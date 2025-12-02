namespace api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Sku { get; set; }
        public string ProductName { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public decimal? Discount { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }


        public ICollection<ProductImage> Images { get; set; }
        public ICollection<InventoryRecord> InventoryRecords { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
