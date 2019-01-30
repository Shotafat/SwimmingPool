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
using SPSQLite.CLASSES.BussinessObjects;
using SPSQLite.CLASSES.Services;
using SPSQLite.Enums;
using System.Globalization;
using SPSQLite.CLASSES;

namespace SwimmingPool
{
    public partial class Form1 : Form
    {

      

        public Form1()
        {
         
        InitializeComponent();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ServiceInstances.Service().GetSubscriberService().GetData();
            //dataGrid_eqimi.DataSource = null;
            //dataGrid_eqimi.DataSource = ServiceInstances.Service().GetDoctorServices().GetData();
            //dataGridView5.DataSource = null;
            //dataGridView5.DataSource = ServiceInstances.Service().GetSubscriptionServices().GetData();

        }

        private void დამატებაToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddAbonent addAbonent = new AddAbonent();


            addAbonent.ShowDialog();
            if (addAbonent.DialogResult == DialogResult.OK)
            {

                Form1_Load(sender, e);
            }
        }

        private void საათებიდაფასებიToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form2 form2 = new Form2();


            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {

                Form1_Load(sender, e);
            }
        }

        private void წაშლაToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CultureInfo provider = new CultureInfo("fr-FR");
            List<SubscriptionSchedule> list = new List<SubscriptionSchedule>
            {
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("02/02/2019 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=15 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("03/02/2009 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=13  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("05/02/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=12},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("06/02/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=13},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("29/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=43},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("28/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=47},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("27/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=12},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("29/01/2019 11:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=20},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("30/01/2019 11:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=21},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("30/01/2019 12:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=30 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 13:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=45},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("23/01/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("01/02/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("25/01/2019 15:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=3 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("29/01/2019 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=15 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("29/01/2019 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=13  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("28/01/2019 10:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=12},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("30/01/2019 11:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=20},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("03/02/2019 12:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=30 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("28/01/2019 13:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=45},
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("28/01/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  }

        };
          foreach (var item in list)
            {
                //SubscriptionSchedule : ISubscriptionSchedule
                ServiceInstances.Service().GetSubscriptionScheduleServices().Add(item);

            }



        }

        private void რედაქტირებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Selected)
            {
                var subscriptionPrice = dataGridView1.SelectedRows[0].DataBoundItem as ISubscriber;
                AddAbonent add = new AddAbonent(subscriptionPrice);

                add.ShowDialog();
                if (add.DialogResult == DialogResult.OK)
                {
                    Form1_Load(sender, e);

                }
            }
            else
                MessageBox.Show("გთხოვთ მონიშნოთ აბონიმენტი!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells[1].Value);
                string b = Convert.ToString(selectedRow.Cells[2].Value);
                label1.Text = a + " " + b;
            }
        }
    }
}


