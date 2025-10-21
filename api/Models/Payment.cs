namespace api.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int TransactionId { get; set; }
        public string Status { get; set; }
        public DateTime? PaidAt { get; set; }
    }
}