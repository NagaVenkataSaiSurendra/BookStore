using BookStore.Exceptions;
using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.DTOs;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository) {
        
            _bookRepository = bookRepository;
        }
        public Book Add(Book book)
        {
            var addBook=_bookRepository.Add(book);
            return addBook;
        }

        public List<Book> GetBooks()
        {
            var books = _bookRepository.GetAll();
            if(books!=null) {
                return books;
            }
            throw new NoBooksAvailableException();
        }

        public Book GetBookById(BookIdDTO bookIdDTO)
        {
            var book=_bookRepository.GetById(bookIdDTO.BookId);
            if(book != null) {
                return book;
            }
            throw new NoSuchBookAvailableException();
        }

        public BookIdDTO RemoveBus(BookIdDTO bookIdDTO)
        {
            throw new NotImplementedException();
        }

        public BookDTO UpdateBus(BookDTO bookDTO)
        {
            throw new NotImplementedException();
        }
    }
}
