namespace api.Models
{
    public class InventoryRecord
    {
        public int InventoryRecordId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}