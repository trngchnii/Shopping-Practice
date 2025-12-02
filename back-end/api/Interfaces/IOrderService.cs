using api.Dtos.Order;

namespace api.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto dto);
    }
}