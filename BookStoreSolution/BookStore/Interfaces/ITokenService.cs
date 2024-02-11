using BookStore.Models.DTOs;

namespace BookStore.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
