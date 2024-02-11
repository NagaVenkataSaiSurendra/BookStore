using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IBookRepository
    {
        public Book Add(Book book);
        public Book Update(Book book);
        public void Delete(Book book);
        public List<Book> GetAll();
        public Book GetById(int id);

    }
}
