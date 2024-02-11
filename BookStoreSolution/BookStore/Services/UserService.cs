using BookStore.Exceptions;
using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.DTOs;
using BookStore.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace BookStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, IBookRepository bookRepository, ITokenService tokenService)
        {

            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _tokenService = tokenService;
        }


        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            if (users != null)
            {
                return users.ToList();
            }
            throw new NoUsersAvailableException();
        }

        

        public UserDTO Login(UserDTO userDTO)
        {

            var user = _userRepository.GetById(userDTO.UserId);

            if (user != null)
            {
                // Validate password using HMACSHA512
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }

                // Generate JWT token and update DTO
                userDTO.Token = _tokenService.GetToken(userDTO);
                userDTO.Password = "";
                userDTO.Email = user.Email;
                return userDTO;
            }

            return null;  // Return null if user does not exist
        }


        public UserDTO Register(UserDTO userDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();

            User user = new User()
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Phone = userDTO.Phone,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                Key = hmac.Key,
                Role = userDTO.Role
            };

            // Add user to repository and return DTO
            var result = _userRepository.Add(user);
            if (result != null)
            {
                userDTO.Password = "";
                return userDTO;
            }

            return null;  // Return null if user registration fails
        }


        public UserDTO UpdateUser(UserDTO userDTO)
        {
            var user = _userRepository.GetById(userDTO.UserId);
            
                user.Username = userDTO.Username;
                user.Email = userDTO.Email;
                user.Phone = userDTO.Phone;
                if (user != null)
                {
                    var res = _userRepository.Update(user);
                    if (res != null)
                    {
                        return userDTO;
                    }
                }
                throw new NoUsersAvailableException();  // Throw exception if user not found
            
        }
    }
}
