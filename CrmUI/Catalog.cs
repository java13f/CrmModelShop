using CrmBL;
using CrmBL.Model;
using System.Data.Entity;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Catalog<T> : Form 
        where T : class
    {
        CrmContext context;
        DbSet<T> set;

        public Catalog(DbSet<T> set, CrmContext context)
        {
            InitializeComponent();
            this.context = context;
            this.set = set;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
        }


        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
                
            }
            else if(typeof(T) == typeof(Seller))
            {

            }
            else if (typeof(T) == typeof(Customer))
            {

            }
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product;

                if (product != null)
                {
                    var form = new ProductForm(product);                    
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;                        
                        context.SaveChanges();
                        dataGridView1.Update();
                    }
                }

            }
            else if(typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller;

                if (seller != null)
                {
                    var form = new SellerForm(seller);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        context.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = set.Find(id) as Customer;

                if (customer != null)
                {
                    var form = new CustomerForm(customer);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer = form.Customer;
                        context.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
        }




    }
}
