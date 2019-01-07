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
            foreach (var item in DatabaseConnection.GetCoachesSource())
            {
                mwvrtneli.Items.Add(item.Name + " " + item.LastName);
            }
            foreach (var item in DatabaseConnection.GetDoctorSource())
            {
                eqimi.Items.Add(item.Name + " " + item.LastName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            DatabaseConnection.insertAbonent(abonentis_saxeli.Text, abonentis_gvari.Text, abonentis_telefoni.Text, abonentis_misamarti.Text, abonentis_dabadeba.Text);
            DatabaseConnection.generateID();
            DialogResult = DialogResult.OK;
            Close();
           
            
           
        }

       
    }
}
