using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSQLite.CLASSES.Services;
using SPSQLite.Enums;

namespace SwimmingPool
{
   
    public partial class AddAbonent : Form
    {
        public List<string> ganrigidge = new List<string>();
        int clock = 9;
        bool shecvla = true;
        public AddAbonent()
        {
          var data =(int)   AttendanceTypes.Attended;
            InitializeComponent();
            grafiki();
            dataGridView1.DataSource = ServiceInstances.Service().GetSubscriptionServices().GetData();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            string columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            string rowName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();


            bool cellValue = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;

            var value = columnName + " - " + rowName;

            if (cellValue)
                ganrigidge.Add(value);
            else
                ganrigidge.Remove(value);

            ganrigidge.Sort();
            archeuligrafiki.DataSource = null;
            archeuligrafiki.DataSource = ganrigidge;
        }

        private void telefoni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
