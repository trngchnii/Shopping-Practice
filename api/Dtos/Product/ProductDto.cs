namespace api.Dtos.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public int Sku { get; set; }
        public string ProductName { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public decimal? Discount { get; set; }
        public string CategoryName { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public bool IsActive { get; set; }
        public IEnumerable<string> ImageUrls { get; set; } = null!;
    }
}