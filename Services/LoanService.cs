using LibraryManagement.Data;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Services
{
    public class LoanService
    {
        private readonly LibraryContext _context;

        public LoanService(LibraryContext context)
        {
            _context = context;
        }

        public void LoanBook(int bookId, int readerId)
        {
            var loan = new Loan
            {
                BookId = bookId,
                ReaderId = readerId,
                LoanDate = DateTime.Now
            };
            _context.Loans.Add(loan);
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                book.IsAvailable = false;
            }
            _context.SaveChanges();
        }

        public void ReturnBook(int loanId)
        {
            var loan = _context.Loans.Find(loanId);
            if (loan != null)
            {
                loan.ReturnDate = DateTime.Now;
                var book = _context.Books.Find(loan.BookId);
                if (book != null)
                {
                    book.IsAvailable = true;
                }
                _context.SaveChanges();
            }
        }

        public List<Loan> GetLoans()
        {
            return _context.Loans.ToList();
        }
    }
}
