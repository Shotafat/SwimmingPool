using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSQLite.CLASSES.Services;

namespace SwimmingPool
{
    public partial class AddPriceForm : Form
    {
        public AddPriceForm()
        {
            InitializeComponent();
        }

        public AddPriceForm(string Hours)
        {
            InitializeComponent();
            if (textBox2.Text != null)
            {
                textBox2.Text = Hours.ToString();
                textBox3.Select();
            }
        }

        public AddPriceForm(SPSQLite.ISubscriptionPrice p)
        {
            InitializeComponent();
            if (textBox2.Text != null)
            {
                textBox2.Text = p.NumberOfHours.ToString();
                textBox3.Text = p.Price.ToString();
            }
        }

        AddAbonent add = new AddAbonent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == string.Empty)
            {
                DialogResult dialogResult = MessageBox.Show("გთხოვთ შეავსოთ პაკეტის ღირებულება!", "Warning", MessageBoxButtons.OKCancel);
                if(dialogResult == DialogResult.OK)
                {
                    this.Show();
                    return;
                }

                else if (dialogResult == DialogResult.Cancel)
                {
                    this.Close();
                    return;
                }
            }

            var Object = ServiceInstances.Service().CreateObject(int.Parse(textBox2.Text), double.Parse(textBox3.Text));
            ServiceInstances.Service().GetSubscriptionPriceServices().Add(Object);

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
