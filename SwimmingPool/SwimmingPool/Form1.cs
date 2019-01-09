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
using SPSQLite.CLASSES;


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
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = SubscriberServices.Object.GetData();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string textboxText = textBox1.Text.ToString();
            int RowIndex = 0;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
               
                    // აი აქ CELL-ის ინდექს რასაც მიანიჭებ იმის მიხედვით მოძებნის 
                    if (row.Cells[0].Value.ToString().Contains(textboxText) || row.Cells[1].Value.ToString().Contains(textboxText) ||
                        row.Cells[2].Value.ToString().Contains(textboxText) || row.Cells[3].Value.ToString().Contains(textboxText) ||
                        row.Cells[4].Value.ToString().Contains(textboxText) || row.Cells[5].Value.ToString().Contains(textboxText))
                    {
                        RowIndex = row.Index;
                        break;
                    }
            }
            dataGridView1.Rows[RowIndex].Selected = true;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var telefoni = dataGridView1.SelectedRows[0].Cells[3].Value;
            var index = DatabaseConnection.Subscriberindex;
            MessageBox.Show(telefoni.ToString()+" "+ index.ToString());
        }

        private void დამატებაToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abonentisdamateba AB = new abonentisdamateba();
            AB.Show();
        }
    }
}


