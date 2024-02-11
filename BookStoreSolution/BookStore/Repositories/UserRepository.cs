using BookStore.Context;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{

        public class UserRepository : IUserRepository
        {
            // DbContext for interacting with the database
            private readonly BookContext _context;

            // Constructor to initialize the repository with the DbContext
            public UserRepository(BookContext context)
            {
                _context = context;
            }

            // Method to add a new user to the database
            public User Add(User user)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }

            // Method to delete a user from the database based on its key (username)
            public User Delete(int id)
            {
                // Retrieve user by key
                var user = GetById(id);

                // Check if the user exists
                if (user != null)
                {
                    // Remove the user from the database
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return user;
                }

                return null;  // Return null if user not found
            }

            // Method to retrieve a list of all users from the database
            public IList<User> GetAll()
            {
                // Check if there are no users in the database
                if (_context.Users.Count() == 0)
                    return null;  // Return null if no users found

                return _context.Users.ToList();  // Return a list of all users
            }

            // Method to retrieve a user from the database based on its key (username)
            public User GetById(int id)
            {
                // Retrieve user using LINQ based on the key
                var user = _context.Users.SingleOrDefault(u => u.UserId == id);
                return user;
            }

            // Method to update a user in the database
            public User Update(User entity)
            {
                // Retrieve existing user by its username
                var user = GetById(entity.UserId);

                // Check if the user exists
                if (user != null)
                {
                    // Mark the user as modified and save changes to the database
                    _context.Entry<User>(user).State = EntityState.Modified;
                    _context.SaveChanges();
                    return user;
                }

                return null;  // Return null if user not found
            }

        }
    }
