using BookStore.Context;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context) { 
           _context = context;
        }
        public Book Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void Delete(Book book)
        {
            var bookToBeRemove = GetById(book.BookId);
            if (bookToBeRemove != null)
            {
                _context.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book GetById(int id)
        {
           var book=  _context.Books.SingleOrDefault(x => x.BookId == id);
            return book;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book Update(Book book)
        {
            var bookToUpdate = GetById(book.BookId);
            if(bookToUpdate != null)
            {
                _context.Entry<Book>(book).State = EntityState.Modified;
                _context.SaveChanges();
                return bookToUpdate;
            }
            return null;
        }
    }
}
