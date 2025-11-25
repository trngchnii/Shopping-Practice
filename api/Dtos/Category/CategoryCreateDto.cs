namespace api.Dtos.Category
{
    public class CategoryCreateDto
    {
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }
    }
}