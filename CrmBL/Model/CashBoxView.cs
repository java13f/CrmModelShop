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
        public ProgressBar ProgressBar { get; set; }
        public Label LeaveCustomersCount { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;

            Label = new Label();
            NumericUpDown = new NumericUpDown();
            ProgressBar = new ProgressBar();
            LeaveCustomersCount = new Label();

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
            NumericUpDown.Maximum = 10000000000000000;

            ProgressBar.Location = new Point(x+250, y);
            ProgressBar.Maximum = cashDesk.MaxQueueLenght;
            ProgressBar.Name = "progressBar" + number;
            ProgressBar.Size = new Size(100, 23);
            ProgressBar.TabIndex = number;
            ProgressBar.Value = 1;

            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new Point(x+400, y);
            LeaveCustomersCount.Name = "label2" + number;
            LeaveCustomersCount.Size = new Size(35, 13);
            LeaveCustomersCount.TabIndex = number;
            LeaveCustomersCount.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            NumericUpDown.Invoke( (Action)delegate { NumericUpDown.Value += e.Price; } );
            ProgressBar.Invoke((Action)delegate { ProgressBar.Value = cashDesk.Count; });
            LeaveCustomersCount.Invoke((Action)delegate { LeaveCustomersCount.Text = cashDesk.ExitCustomer.ToString(); });
        }
    }
}
