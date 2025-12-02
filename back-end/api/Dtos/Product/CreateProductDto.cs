namespace api.Dtos.Product
{
    public class CreateProductDto
    {
        public int Sku { get; set; }
        public string ProductName { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public decimal? Discount { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public bool IsActive { get; set; }
    }
}