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
            grafiki();
            
        }

        public void grafiki()
        {
            dataGridView1.DataSource = null;
            for (int i = clock; i < 20; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i - 9].Cells[0].Value = Convert.ToString(i + ":00");
             }
            foreach (DataGridViewColumn column in dataGridView1.SelectedColumns)
            {
                string selectedColumn = column.HeaderText.ToString();
                MessageBox.Show(selectedColumn);
            }
            
            //var k = dataGridView1.SelectedRows[0].HeaderCell.Value;
            //MessageBox.Show(k.ToString());
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var k = dataGridView1.SelectedRows[0].HeaderCell.Value;
            MessageBox.Show(k.ToString());
        }
    }
}
