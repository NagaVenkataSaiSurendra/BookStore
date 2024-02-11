namespace BookStore.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public bool? IsAdmin { get; set; }
        public string? Token { get; set; }
    }
}
