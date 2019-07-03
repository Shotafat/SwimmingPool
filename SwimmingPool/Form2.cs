using SPSQLite.CLASSES.Services;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class Form2 : Form
    {
        public string NumberofHour { get; set; }
        public string SelectedRowPrice { get; set; }

        public Form2()
        {
            InitializeComponent();
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            EditForm edit = new EditForm();
            edit.ShowDialog();
            if (edit.DialogResult == DialogResult.OK)
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
            dataGridView1.Columns[0].Visible = false;            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NumberofHour = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            SelectedRowPrice = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            setDatagrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells[0].Value);

                var gela = ServiceInstances.Service().GetSubscriptionPriceServices().GetData()
                    .Where(x => x.ID == int.Parse(a)).FirstOrDefault();

                AddPriceForm addform = new AddPriceForm(gela);
                addform.ShowDialog();

                ServiceInstances.Service().GetSubscriptionPriceServices().Edit(gela);

                if (addform.DialogResult == DialogResult.OK)
                {
                    var gelas = ServiceInstances.Service().GetSubscriptionPriceServices().GetData();
                    Form2_Load(sender, e);
                }

                //ServiceInstances.Service().GetSubscriptionPriceServices().Delete(gela);

                //foreach (var item in ServiceInstances.Service().GetSubscriptionPriceServices().GetData())
                //{
                //    Console.WriteLine(item.ID);
                //}

            }
        }
    }
}
