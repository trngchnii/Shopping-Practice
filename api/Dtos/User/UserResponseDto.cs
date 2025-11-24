namespace api.Dtos.User
{
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
    }
}