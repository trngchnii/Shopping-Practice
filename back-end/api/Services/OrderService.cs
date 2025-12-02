using api.Dtos.Order;
using api.Interfaces;

namespace api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryService _inventoryService;

        public OrderService(IProductRepository productRepository, IInventoryService inventoryService)
        {
            _productRepository = productRepository;
            _inventoryService = inventoryService;
        }

        public Task<OrderDto> CreateOrderAsync(CreateOrderDto dto)
        {

        }
    }
}