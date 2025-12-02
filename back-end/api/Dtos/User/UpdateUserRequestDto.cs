namespace api.Dtos.User
{
    public class UpdateUserRequestDto
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string RoleName { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
