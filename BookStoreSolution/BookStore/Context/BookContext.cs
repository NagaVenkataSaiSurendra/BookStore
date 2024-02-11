using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Context
{
    public class BookContext :DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
