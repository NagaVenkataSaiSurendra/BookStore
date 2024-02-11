using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }

        public string Phone { get; set; }
        public string Role {  get; set; }
        public bool IsAdmin {  get; set; }
        public byte[] Key { get; set; }

    }
}
