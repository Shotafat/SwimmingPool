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
            dataGridView1.DataSource = DatabaseConnection.GetAbonentSource();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            abonentisdamateba AD = new abonentisdamateba();
            AD.ShowDialog();
            if (AD.DialogResult == DialogResult.OK)
            {
                Form1_Load(sender, e);
                MessageBox.Show("აბონენტი წარმატებით დაემატა");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            mcvrtnelieqimi ME = new mcvrtnelieqimi();
            ME.ShowDialog();
        }




      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string textboxText = textBox1.Text.ToString();
            int RowIndex = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
               
                    // აი აქ CELL-ის ინდექს რასაც მიანიჭებ იმის მიხედვით მოძებნის 
                    if (row.Cells[0].Value.ToString().Equals(textboxText) || row.Cells[1].Value.ToString().Equals(textboxText) ||
                        row.Cells[2].Value.ToString().Equals(textboxText) || row.Cells[3].Value.ToString().Equals(textboxText) ||
                        row.Cells[4].Value.ToString().Equals(textboxText) || row.Cells[5].Value.ToString().Equals(textboxText))
                    {
                        RowIndex = row.Index;
                        break;


                    }
                


            }
            dataGridView1.Rows[RowIndex].Selected = true;

        }
    }
}


