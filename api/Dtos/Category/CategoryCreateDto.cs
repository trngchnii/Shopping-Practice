namespace api.Dtos.Category
{
    public class CategoryCreateDto
    {
        public string CategoryName { get; set; } = null!;
        public int? ParentId { get; set; }
    }
}