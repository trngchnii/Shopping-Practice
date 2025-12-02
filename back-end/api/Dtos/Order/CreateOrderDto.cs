namespace api.Dtos.Order
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }
}