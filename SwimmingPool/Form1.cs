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
<<<<<<< HEAD
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
=======
            abonementis_damateba AB = new abonementis_damateba();
            AB.ShowDialog();
>>>>>>> eb07f53c107f710a0876ea817db37e13a5f82f76
        }
    }
}
