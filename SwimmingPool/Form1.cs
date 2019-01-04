using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions;


namespace SwimmingPool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openAD();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openME();
        }
        public void openAD()
        {
            abonentisdamateba AD = new abonentisdamateba();
            AD.ShowDialog();
        }
        public void openME()
        {
            mcvrtnelieqimi ME = new mcvrtnelieqimi();
            ME.ShowDialog();
        }
    }
}
