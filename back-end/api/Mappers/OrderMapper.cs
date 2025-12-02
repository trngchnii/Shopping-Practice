using api.Dtos.Order;
using api.Models;

namespace api.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                OrderId = order.OrderId,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                Items = order.OrderItems.Select(x => new OrderItemDto
                {
                    ProductName = x.Product.ProductName,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                }).ToList()
            };
        }
    }
}