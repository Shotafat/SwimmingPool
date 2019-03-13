using SPSQLite.CLASSES.BussinessObjects;
using SPSQLite.CLASSES.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class Limit : Form
    {
        public Limit()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            textBox1.Text = ServiceInstances.Service().GetCapicityServices().GetData().Last().CapicityValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nika = Convert.ToInt32(textBox1.Text);
            Capicity cap = new Capicity();
            cap.CapicityValue = nika;
            ServiceInstances.Service().GetCapicityServices().Add(cap);
            Close();
        }

       
    }
}
