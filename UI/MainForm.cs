using System;
using System.Linq;
using System.Windows.Forms;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Services;

namespace Бібліотека.UI
{
    public partial class MainForm : Form
    {
        private LibraryContext _context;
        private BookService _bookService;

        public MainForm()
        {
            InitializeComponent();
            _context = new LibraryContext();
            _bookService = new BookService(_context);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            dataGridViewBooks.DataSource = _bookService.GetAllBooks().ToList();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var book = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Year = int.Parse(txtYear.Text),
                Genre = txtGenre.Text,
                IsAvailable = true
            };

            _bookService.AddBook(book);
            LoadBooks();
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                var bookId = (int)dataGridViewBooks.SelectedRows[0].Cells["Id"].Value;
                _bookService.DeleteBook(bookId);
                LoadBooks();
            }
        }
    }
}
