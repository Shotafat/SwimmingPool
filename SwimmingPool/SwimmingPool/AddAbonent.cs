using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SwimmingPool
{

    public partial class AddAbonent : Form
    {
        public List<string> ganrigidge = new List<string>();
        
        public AddAbonent()
        {
            InitializeComponent();
            grafiki();
        }

        public void grafiki()
        {
            dataGridView1.DataSource = null;
            for (int i = 9; i < 20; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i - 9].Cells[0].Value = Convert.ToString(i + ":00");
            }

            for (int i = 0; i < 11; i++)
            {
                for (int ii = 0; ii < 7; ii++)
                {
                    dataGridView1.Rows[i].Cells[ii].Style.BackColor = Color.Snow;
                }
            }
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Green;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= 0)
                return;
            string columnName = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            string rowName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            var value = columnName + " - " + rowName;

            bool cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValueType.IsSealed;

            Color feri = default(Color);

            if (cellValue && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Green)
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = feri;
            else
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != feri)
            {
                ganrigidge.Add(value);
                MessageBox.Show("ბაზაში დაემატა შემდეგი მონაცემები" + " " + value);
            }
            else
            {
                ganrigidge.Remove(value);
                MessageBox.Show("ბაზიდან წაიშალა შემდეგი მონაცემები" + " " + value);
            }
            archeuligrafiki.DataSource = null;
            archeuligrafiki.DataSource = ganrigidge;
        }
    }
}
