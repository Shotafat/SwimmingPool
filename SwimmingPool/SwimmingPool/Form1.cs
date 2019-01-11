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
using SPSQLite.CLASSES.Services;



namespace SwimmingPool
{
    public partial class Form1 : Form
    {

      

        public Form1()
        {
         
        InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //dataGrid_eqimi.DataSource = null;
            //dataGrid_eqimi.DataSource = ServiceInstances.Service().GetDoctorServices().GetData();
            //dataGridView5.DataSource = null;
            //dataGridView5.DataSource = ServiceInstances.Service().GetSubscriptionServices().GetData();

        }

        public void ADDABONENT(object sender, EventArgs e)
        {
            AddAbonent addAbonent = new AddAbonent();
            addAbonent.ShowDialog();
        }
    }
}


