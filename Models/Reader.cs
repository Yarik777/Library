using System;
using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Loan> Loans { get; set; } 
    }
}
