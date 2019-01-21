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

namespace SwimmingPool
{
    public partial class Form2 : Form
    {
        public string NumberofHour { get; set; }
        public string SelectedRowPrice { get; set; }
        public Form2()
        {
            InitializeComponent();
           

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            EditForm edit = new EditForm();
            edit.ShowDialog();
            if(edit.DialogResult == DialogResult.OK)
            {
                Form2_Load(sender, e);

            }
         

             
        }

        private void button1_Click(object sender, EventArgs e)
        {
             AddPriceForm addform = new AddPriceForm();
            addform.ShowDialog();
            if (addform.DialogResult == DialogResult.OK)
            {
                Form2_Load(sender, e);


            }
      


        }

        public void setDatagrid()
        {
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = ServiceInstances.Service().GetSubscriptionPriceServices().GetData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NumberofHour = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            SelectedRowPrice=  dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
    
     
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            setDatagrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
