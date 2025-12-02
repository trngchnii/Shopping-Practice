namespace api.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ImageUrl { get; set; }
        public bool isPrimary { get; set; }
        public int SortOrder { get; set; } = 0;
    }
}