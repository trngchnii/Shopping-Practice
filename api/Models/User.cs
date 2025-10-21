namespace api.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }

        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
