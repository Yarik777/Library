using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using System.Data.SqlClient; 
namespace LibraryManagement.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5SK7OKG\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Reader)
                .WithMany(r => r.Loans)
                .HasForeignKey(l => l.ReaderId);
        }
    }
}
