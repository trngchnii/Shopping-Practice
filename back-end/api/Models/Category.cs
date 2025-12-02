namespace api.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }
        public Category Parent { get; set; }


        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}