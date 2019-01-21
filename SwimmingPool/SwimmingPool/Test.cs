using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPSQLite.CLASSES;

namespace SwimmingPool
{
    public partial class Test : Form
    {
        HealthNoticeServices h_service = new HealthNoticeServices();
        HealthNotice h_class = new HealthNotice();
        public Test()
        {
            InitializeComponent();
            comboBox1.DataSource = GetComboData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h_class.DateCreated = dateTimePicker1.Value;
            h_class.AbonentId = Convert.ToInt32(textBox1.Text);
            h_service.Add(h_class);
        }

        private List<SPSQLite.IHealthNotice> GetComboData()
        {
             var list = h_service.GetData().ToList();
            return list;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var hn = comboBox1.SelectedItem as HealthNotice;
            h_service.Delete(hn);
            var list = h_service.GetData().ToList();
            comboBox1.DataSource = list;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text;              
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var id = h_service.GetData().Select(x => x.DateCreated == Convert.ToDateTime(comboBox1.Text));


            h_class.DateCreated = Convert.ToDateTime(textBox2.Text);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = h_service.GetData();
        }

    }
}
