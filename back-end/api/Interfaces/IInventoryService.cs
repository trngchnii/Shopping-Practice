namespace api.Interfaces
{
    public interface IInventoryService
    {
        Task<bool> CheckStockAsync(int productId, int quantity);
        Task DecreaseStockAsync(int productId, int quantity);
        Task IncreaseStockAsync(int productid, int quantity);
    }
}