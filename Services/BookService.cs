using LibraryManagement.Data;
using LibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Services
{
    public class BookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public Book GetBook(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
