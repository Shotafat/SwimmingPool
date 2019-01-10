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
   
    public partial class abonentisdamateba : Form
    {

    

        public abonentisdamateba()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            DatabaseConnection.insertAbonent(abonentis_saxeli.Text, abonentis_gvari.Text, abonentis_telefoni.Text, abonentis_misamarti.Text, abonentis_dabadeba.Text);
           
            DialogResult = DialogResult.OK;
            Close();
           
            
           
        }

       
    }
}
