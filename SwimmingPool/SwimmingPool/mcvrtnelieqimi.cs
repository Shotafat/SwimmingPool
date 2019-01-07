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

namespace SwimmingPool
{
    public partial class mcvrtnelieqimi : Form
    {
        public mcvrtnelieqimi()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

      private void button1_Click(object sender, EventArgs e)
        {

            DatabaseConnection.insertDoctor( eqimis_saxeli.Text.ToString(), eqimis_gvari.Text.ToString());
            DatabaseConnection.insertCoach( mwvrtnelis_saxeli.Text.ToString(), mwvrtnelis_gvari.Text.ToString());
            DatabaseConnection.insertSubscribtionPrice(Convert.ToInt16(gadaxda_saati.Text), Convert.ToDouble(gadaxda_fasi.Text));

            this.Close();
        }
    }
}
