using BookStore.Models;
using BookStore.Models.DTOs;

namespace BookStore.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book Add(Book book);
        BookIdDTO RemoveBus(BookIdDTO bookIdDTO);
        BookDTO UpdateBus(BookDTO bookDTO);
        Book GetBookById(BookIdDTO bookIdDTO);
    }
}
