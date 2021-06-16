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
    public partial class frmAddRemoveCust : Form
    {
        public frmAddRemoveCust()
        {
            InitializeComponent();
        }

        private void lblPrice_Click(object sender, EventArgs e) 
        {
            //DELETE THIS!
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer
            {
                //CustomerID = Convert.ToInt32(txtCustID.Text),
                DateOfBirth = Convert.ToDateTime(dtpDOB.Value),
                FirstName = txtFName.Text,
                LastName =txtLName.Text,
                Appelation = txtAppelation.Text

            };
            CustomerDB.AddCustomer(newCustomer);
            Close();

        }
    }
}
