using LibraryManagement.Data;
using LibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Services
{
    public class ReaderService
    {
        private readonly LibraryContext _context;

        public ReaderService(LibraryContext context)
        {
            _context = context;
        }

        public void AddReader(Reader reader)
        {
            _context.Readers.Add(reader);
            _context.SaveChanges();
        }

        public void DeleteReader(int readerId)
        {
            var reader = _context.Readers.Find(readerId);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
                _context.SaveChanges();
            }
        }

        public Reader GetReader(int readerId)
        {
            return _context.Readers.Find(readerId);
        }

        public List<Reader> GetAllReaders()
        {
            return _context.Readers.ToList();
        }

        public void UpdateReader(Reader reader)
        {
            _context.Readers.Update(reader);
            _context.SaveChanges();
        }
    }
}
