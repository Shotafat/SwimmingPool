using SPSQLite.CLASSES;
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
    public partial class gadasaxadi : Form
    {
        SubscriptionPriceServices SS = new SubscriptionPriceServices();
        public gadasaxadi()
        {
            InitializeComponent();
        }

        private void gamosvla_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Senaxva_Click(object sender, EventArgs e)
        {
            SS.Add(new SubcsriptionPrice
            {
                NumberOfHours = Convert.ToInt16( gadaxda_saati.Text),
                Price = Convert.ToDouble(gadaxda_fasi.Text)
            });

            Close();
        }
    }
}
