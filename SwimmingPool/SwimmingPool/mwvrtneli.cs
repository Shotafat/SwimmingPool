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
    public partial class mwvrtneli : Form
    {
        public mwvrtneli()
        {
            InitializeComponent();
        }

        private void gamosvla_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void shenaxva_Click(object sender, EventArgs e)
        {
            CoachServices CS = new CoachServices();
            CS.Add(new Coach
            {
                Name = mwvrtneli_saxeli.Text,
                LastName = mwvrtneli_gvari.Text
            });

            Close();
        }
    }
}
