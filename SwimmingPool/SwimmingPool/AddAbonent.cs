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
        public List<string> ganrigidge = new List<string>();
        int clock = 9;
        bool shecvla = true;
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
            
           
        }
        int indexcell;
        int indexrow;
        string valuecell;
        string valuerow;
        string value;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var findindex = 0;
             indexcell = dataGridView1.SelectedCells[0].ColumnIndex;
             indexrow = dataGridView1.CurrentCell.RowIndex;

             valuecell = dataGridView1.Columns[indexcell].HeaderText;
             valuerow = dataGridView1.Rows[indexrow].Cells[0].Value.ToString();

             value = valuecell + "-" + valuerow;

            if (shecvla==true)
            {
                
                ganrigidge.Add(value);
                archeuligrafiki.Items.Add(value);
            }
            else
            {

                findindex = archeuligrafiki.FindString(value);
                archeuligrafiki.Items.Remove(findindex);
            }
            
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            var name = archeuligrafiki.FindString(value);
            MessageBox.Show(name.ToString());
            if (archeuligrafiki.Items[name].ToString() == value)
            {
                if (shecvla == true)
                    shecvla = false;
                else
                    shecvla = true;
            }

        }
    }
}
