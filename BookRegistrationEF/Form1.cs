using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistrationEF
{
    public partial class AddBookButton : Form
    {
        public AddBookButton()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateBookList();
        }

        private void PopulateBookList()
        {
            List<Book> books = BookDb.GetAllBooks();

            BooksComboBox.DataSource = books;
            BooksComboBox.DisplayMember = nameof(Book.Title);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.ISBN = "79123";
            b.Title = "Joe's Text Book";
            b.Price = 10;

            BookDb.AddBook(b);
            MessageBox.Show("Book added!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Object Initialization Syntax
            Customer newCust = new Customer()
            {
                FirstName = "J",
                LastName = "H",
                DateOfBirth = new DateTime(1980, 1, 1),
                Title = "Mr."
            };

            newCust = CustomerDb.AddCustomer(newCust);
            MessageBox.Show("Customer added!");

            newCust.FirstName = "Jim";
            CustomerDb.Update(newCust);
            MessageBox.Show("Customer updated!");

            CustomerDb.DeleteCustomer(newCust);
            MessageBox.Show("Customer deleted!");
        }
    }
}
