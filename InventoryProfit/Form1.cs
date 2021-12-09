using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryProfit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lblDays.Text = "";
            lblLastInventory.Text = "";

            var money = Convert.ToDouble(txtInventory.Text);

            if (txtLastInventory.Text == null || txtLastInventory.Text == "")
            {
                if (txtDays.Text != "" && txtDays.Text != null)
                {
                    int days = Convert.ToInt16(txtDays.Text);
                    for (int i = 0; i < days; i++)
                    {
                        var percent = money * Convert.ToDouble(Convert.ToDecimal(txtPercent.Text) / 100);
                        money = percent + money;
                    }

                    lblLastInventory.Text = Convert.ToDouble(money).ToString("#,##0.00");
                }
            }
            else if (txtDays.Text == null || txtDays.Text == "")
            {
                if (txtLastInventory.Text != null && txtLastInventory.Text != "")
                {
                    int days = 0;
                    string lastInventory = txtLastInventory.Text.Replace(",", "");
                    while (money < Convert.ToInt64(lastInventory))
                    {
                        var percent = money * Convert.ToDouble(Convert.ToDecimal(txtPercent.Text) / 100);
                        money = percent + money;
                        days++;
                    }
                    lblDays.Text = days.ToString("#,##0.00");
                }
            }
            //else if (txtPercent.Text == null || txtPercent.Text == "")
            //{
            //    int days = Convert.ToInt16(txtDays.Text);
            //    while (money < Convert.ToInt64(txtLastInventory.Text))
            //    {
            //        for (int i = 0; i < days; i++)
            //        {
            //            var percent = money * Convert.ToDecimal(Convert.ToDecimal(txtPercent.Text) / 100);
            //            money = percent + money;
            //        }
            //    }
            //}
        }

        public string setComma(double number)
        {
            string x = string.Format("{0:n0}", number);
            return x;
        }
        public double UptoTwoDecimalPoints(double num)
        {
            var totalCost = Convert.ToDouble(String.Format("{0:0.00}", num));
            return totalCost;
        }

        private void txtInventory_TextChanged(object sender, EventArgs e)
        {
            string value = txtInventory.Text.Replace(",", "");
            ulong ul;
            if (ulong.TryParse(value, out ul))
            {
                txtInventory.TextChanged -= txtInventory_TextChanged;
                txtInventory.Text = string.Format("{0:#,#}", ul);
                txtInventory.SelectionStart = txtInventory.Text.Length;
                txtInventory.TextChanged += txtInventory_TextChanged;
            }
        }

        private void txtLastInventory_TextChanged(object sender, EventArgs e)
        {
            string value = txtLastInventory.Text.Replace(",", "");
            ulong ul;
            if (ulong.TryParse(value, out ul))
            {
                txtLastInventory.TextChanged -= txtLastInventory_TextChanged;
                txtLastInventory.Text = string.Format("{0:#,#}", ul);
                txtLastInventory.SelectionStart = txtLastInventory.Text.Length;
                txtLastInventory.TextChanged += txtLastInventory_TextChanged;
            }
        }
    }
}
