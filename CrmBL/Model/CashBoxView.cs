using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmBL.Model
{
    public class CashBoxView
    {
        CashDesk cashDesk;

        public Label Label { get; set; }
        public NumericUpDown NumericUpDown { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;

            Label = new Label();
            NumericUpDown = new NumericUpDown();

            Label.AutoSize = true;
            Label.Location = new Point(x, y);
            Label.Name = "label"+number;
            Label.Size = new Size(35, 13);
            Label.TabIndex = number;
            Label.Text = cashDesk.ToString();

            NumericUpDown.Location = new Point(x+70, y);
            NumericUpDown.Name = "numericUpDown"+number;
            NumericUpDown.Size = new Size(120, 20);
            NumericUpDown.TabIndex = number;
        }
    }
}
