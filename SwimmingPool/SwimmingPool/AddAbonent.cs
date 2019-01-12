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
    public partial class AddAbonent : Form
    {
        int clock = 9;
        public AddAbonent()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            //dataGridView1.Rows[0].Cells[0].Value = Convert.ToString("09:00");
            for (int i = clock; i < 20; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i-9].Cells[0].Value = Convert.ToString(i+":00");
            }
           //dataGridView1.Rows[0].Cells[0].Value="09:00";
           // string row = "10:00";
           // dataGridView1.Rows.Add(row);
           // dataGridView1.Rows[1].Cells[0].Value = "10:00";
           
        }
    }
}
