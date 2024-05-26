using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Loan> Loans { get; set; } 
    }
}
