using CrmBL.Model;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }
        public SellerForm()
        {
            InitializeComponent();
        }

        public SellerForm(Seller seller) : this()
        {
            Seller = seller;
            textBox1.Text = Seller.Name;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var s = Seller ?? new Seller();
            s.Name = textBox1.Text;
            Seller = s;
                        
            Close();
        }
    }
}
