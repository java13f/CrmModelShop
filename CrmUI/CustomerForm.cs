using CrmBL.Model;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }
        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(Customer customer) : this()
        {
            Customer = customer;
            textBox1.Text = Customer.Name;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var c = Customer ?? new Customer();           
            c.Name = textBox1.Text;
            Customer = c;
            Close();
        }
    }
}
