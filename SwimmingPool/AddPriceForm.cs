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

        public AddPriceForm(string numberofHour)
        {
            InitializeComponent();
            if (textBox2.Text!=null)
               textBox2.Text = numberofHour;
        }


        AddAbonent add = new AddAbonent();
        protected override void OnLoad(EventArgs e)
        {

          

            base.OnLoad(e); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var Object =  ServiceInstances.Service().CreateObject(int.Parse(textBox2.Text), double.Parse(textBox3.Text));
           ServiceInstances.Service().GetSubscriptionPriceServices().Add(Object);

            DialogResult = DialogResult.OK;
          
            Close();


        }
    }
}
