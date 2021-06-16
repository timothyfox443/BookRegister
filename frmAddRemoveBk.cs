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
    public partial class frmAddBook : Form
    {
        public frmAddBook()
        {
            InitializeComponent();
        }

        private void btnAddBookForm_Click(object sender, EventArgs e)
        {
            Book newBook = new Book
            {
                ISBN = txtBookISBN.Text,
                Price = Convert.ToDouble(txtBookPrice.Text),
                Title = txtBookTitle.Text

            };
            BookDB.AddBook(newBook);
            Close();
            
        }
    }
}
