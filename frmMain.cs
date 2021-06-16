using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegister
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            List<Book> bookList = BookDB.GetAllBooks();
            List<Customer> customerList = CustomerDB.GetAllCustomers();

            PopulateCmbBook(bookList);

            PopulateCmbCustomer(customerList);
        }

        private void PopulateCmbCustomer(List<Customer> customerList)
        {
            cmbCustomer.Items.Clear();
            foreach (Customer customer in customerList)
            {
                cmbCustomer.Items.Add(customer);
            }
        }

        private void PopulateCmbBook(List<Book> bookList)
        {
            cmbBook.Items.Clear();
            foreach(Book book in bookList)
            {
                cmbBook.Items.Add(book);
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddBook addRemoveBook = new frmAddBook();
            addRemoveBook.ShowDialog();
            List<Book> allBooks = BookDB.GetAllBooks();
            PopulateCmbBook(allBooks);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmAddRemoveCust addRemoveCust = new frmAddRemoveCust();
            addRemoveCust.ShowDialog();
            List<Customer> allCustomers = CustomerDB.GetAllCustomers();
            PopulateCmbCustomer(allCustomers);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Book newBook = cmbBook.SelectedItem as Book;
            Registration newRegistration = new Registration
            {
                CustomerID = cmbCustomer.SelectedIndex + 1,
                ISBN = newBook.ISBN,
                RegDate = dtbRegDate.Value

            };
            BookRegistrationDB.AddRegistration(newRegistration);
            Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            cmbBook.SelectedIndex = -1;
            dtbRegDate.Value = System.DateTime.Now;
        }
    }
}
