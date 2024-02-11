using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IUserRepository
    {
        public User Add(User user);
        public User Update(User entity);
        public User Delete(int id);
        public IList<User> GetAll();
        public User GetById(int id);
    }
}
