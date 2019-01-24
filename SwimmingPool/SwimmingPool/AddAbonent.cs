using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SPSQLite;
using SPSQLite.CLASSES;
using SPSQLite.CLASSES.BussinessObjects;
using SPSQLite.CLASSES.Services;
using SPSQLite.UIMethods;

namespace SwimmingPool
{

    public partial class AddAbonent : Form
    {
        public List<string> ganrigidge = new List<string>();
        public List<int> columni = new List<int>();
        public List<int> rovsi = new List<int>();

        public AddAbonent()
        {
            InitializeComponent();
            grafiki();
            DateTime start = dateTimePicker1.Value;
            DateTime End = dateTimePicker1.Value.AddDays(3);
            gridFillter(dataGridView1, start, End);
        }

        public AddAbonent(ISubscriber subscriber) : this()
        {
            if (subscriber != null)
            {
                label6.Text = "რ" + " " + "ე" + " " + "დ" + " " + "ა" + " " + "ქ" + " " + "ტ" + " " + "ი" + " " + "რ" + " " + "ე" + " " + "ბ" + " " + "ა";

                saxeli.Text = subscriber.Name;
                gvari.Text = subscriber.LastName;
                asaki.Text = subscriber.DateOfBirth.ToString();
                telefoni.Text = subscriber.PhoneNumber;
                misamarti.Text = subscriber.Adress;
                shenaxva.Text = "რედაქტირება";
            }

        }

        public void  gridFillter (DataGridView SubscriberSchedul, DateTime Start, DateTime End )
        {
            //        FormatedData
            //{
            //    public int Hours { get; set; }
            //    public List<DataInput> DatainputList { get; set; }

            //}
            //dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = value;

           // MessageBox.Show("GAESHVA!");


            SubscriberSchedul.DataSource = null;
            InputMethods.Filldata(Start, End);

            foreach (var item in InputMethods.DATAforInput)
            {

             //   MessageBox.Show("SIGRDZE " + item.DatainputList.Count);

                //if (item.Date.Hour < 9)
                //    item.Date.Hour = item.Date.Hour + 12;
               

                for (int i = 0; i < InputMethods.DATAforInput.Count; i++)
                {
                    
                    //int a = item.Hours - 9;
                    //int b = (int)item.DatainputList[i].Date.DayOfWeek + 1;
                    // MessageBox.Show("INDEXROW " + a + " INDEXCOLUMN" + b);

                    SubscriberSchedul.Rows[item.Date.Hour - 9].Cells[(int)item.Date.Date.DayOfWeek].Value = item.Datelist.ToString(); ;  //item.DatainputList[i].Datelist.ToString(); // item.DatainputList[i].Date.ToString()+" "+ 

                }


            }



        }



        public void grafiki()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "";
            for (int i = 10; i < 21; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i - 9].Cells[0].Value = Convert.ToString(i-1 + ":00");
            }

            for (int i = 0; i < 11; i++)
            {
                for (int ii = 0; ii < 7; ii++)
                {
                    dataGridView1.Rows[i].Cells[ii].DataGridView.DefaultCellStyle.BackColor = Color.Snow;
                }
            }
            for (int ii = 0; ii < 7; ii++)
            {
                dataGridView1.Rows[0].Cells[ii].Value = DateTime.Now ;
            }

            //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Green;
        }

        public void ricxvebi(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void simboloebi(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void cheked(object sender, EventArgs e)
        {
            if (ara.Checked)
            {
                diax.Enabled = false;
            }
            else
            {
                diax.Enabled = true;
            }

            if (diax.Checked)
            {
                ara.Enabled = false;
            }
            else
            {
                ara.Enabled = true;
            }
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(e.ColumnIndex.ToString());
            bool sell = columni.Contains(e.ColumnIndex);
            //bool rov = rovsi.Contains(e.RowIndex);
            if (sell && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != Color.Green)
                return;
            else
            {
                columni.Add(e.ColumnIndex);
                rovsi.Add(e.RowIndex);
                if (e.ColumnIndex <= 0)
                {
                    return;
                }

                string columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                string rowName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var value = columnName + " - " + rowName;

                bool cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValueType.IsSealed;

                Color feri = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].DataGridView.DefaultCellStyle.BackColor;

                //MessageBox.Show(feri.ToString());

                if (cellValue && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Green)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = feri;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;

                }

                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != feri)
                {
                    ganrigidge.Add(value);
                    //MessageBox.Show("ბაზაში დაემატა შემდეგი მონაცემები" + " " + value);
                }
                else
                {
                    ganrigidge.Remove(value);
                    columni.Remove(e.ColumnIndex);
                    //MessageBox.Show("ბაზიდან წაიშალა შემდეგი მონაცემები" + " " + value);
                }
                archeuligrafiki.DataSource = null;
                archeuligrafiki.DataSource = ganrigidge;
            }
            
        }

        private void shenaxva_Click(object sender, EventArgs e)
        {
            var gela = ServiceInstances.Service().CreateObjectForSub(Convert.ToInt16(nomeri.Text), saxeli.Text, gvari.Text, DateTime.Parse(asaki.Text), telefoni.Text, misamarti.Text);

            ServiceInstances.Service().GetSubscriberService().Add(gela);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
