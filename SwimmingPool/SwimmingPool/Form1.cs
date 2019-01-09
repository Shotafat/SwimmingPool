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
        DoctorServices DS = new DoctorServices();
        CoachServices CS = new CoachServices();
        SubscriptionPriceServices SP = new SubscriptionPriceServices();
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGrid_eqimi.DataSource = null;
            dataGrid_eqimi.DataSource = DS.GetData();
            dataGridView5.DataSource = null;
            dataGridView5.DataSource = SP.GetData();

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
           
            MessageBox.Show(telefoni.ToString());
        }

        public void abonentisdamateba(object sender, EventArgs e)
        {
            abonentisdamateba AB = new abonentisdamateba();
            AB.Show();
        }

        public void eqimi_(object sender, EventArgs e)
        {
            eqimi eqimi = new eqimi();
            eqimi.ShowDialog();
            
        }

        public void mwvrtneli_(object sender, EventArgs e)
        {
            mwvrtneli mwv = new mwvrtneli();
            mwv.ShowDialog();
        }

        public void gadasaxadi_(object sender, EventArgs e)
        {
            gadasaxadi gadasaxadi = new gadasaxadi();
            gadasaxadi.ShowDialog();
        }

        private void dataGrid_eqimi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var iind = dataGrid_eqimi.SelectedRows[0].Cells[0].Value;
            MessageBox.Show(iind.ToString());
        }
    }
}


