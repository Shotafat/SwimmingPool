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
            abonementis_damateba AB = new abonementis_damateba();
            AB.ShowDialog();
        }
    }
}
