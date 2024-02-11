using BookStore.Models;
using BookStore.Models.DTOs;

namespace BookStore.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
        UserDTO UpdateUser(UserDTO userDataDTO);
       
        List<User> GetAllUsers();
    }
}
