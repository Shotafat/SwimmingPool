using SPSQLite;
using SPSQLite.CLASSES;
using SPSQLite.CLASSES.Services;
using SPSQLite.Enums;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

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
        
            
            dataGridView1.AutoGenerateColumns = true;
            grafiki();
            JoinClasses();
            //dataGrid_eqimi.DataSource = null;
            //dataGrid_eqimi.DataSource = ServiceInstances.Service().GetDoctorServices().GetData();
            //dataGridView5.DataSource = null;
            //dataGridView5.DataSource = ServiceInstances.Service().GetSubscriptionServices().GetData();

        }

        private void დამატებაToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }
        public void JoinClasses()
        {

           

            

         var SubscribtionTable=DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>();
            var HealthTable = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.HealthNotice>();
           
           var fillgrid = (from o in SubscribtionTable
                           join a in HealthTable on o.SubscriberID equals a.SubscriberID 
                           select new { აბონიმენტი= o.IDnumber, სახელი=o.Subscriber_.Name,
                               გვარი =o.Subscriber_.LastName, ასაკი=Math.Round((DateTime.Now-o.Subscriber_.DateOfBirth).TotalDays/365,0), ჯანმრთელობისცნობა=a.YesNO, ფასი=o.SubscriberPrice_.Price}).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fillgrid;
        }

   

     

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells[1].Value);
                string b = Convert.ToString(selectedRow.Cells[2].Value);
                //label1.Text = a + " " + b;
            }
        }

        private void დამატებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAbonent addAbonent = new AddAbonent();


            addAbonent.ShowDialog();
            if (addAbonent.DialogResult == DialogResult.OK)
            {

                Form1_Load(sender, e);
            }
        }

        private void რედაქტირებაToolStripMenuItem_Click_1(object sender, EventArgs e)
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
            {
                MessageBox.Show("გთხოვთ მონიშნოთ აბონიმენტი!");
            }
        }



      


        private void საათებიდაფასებიToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
          
            Form2 form2 = new Form2();


            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {

                Form1_Load(sender, e);
            }
        }

        private void წაშლაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConnection.insertSubscribtionPrice(2, 2.5);
            DatabaseConnection.insertSubscribtionPrice(3, 40.5);
            DatabaseConnection.insertSubscribtionPrice(4, 30.5);
            DatabaseConnection.insertSubscribtionPrice(5, 20.5);
            DatabaseConnection.insertSubscribtionPrice(6, 12.5);
            DatabaseConnection.insertSubscribtionPrice(7, 9.5);
            DatabaseConnection.insertSubscribtionPrice(8, 8.5);
            DatabaseConnection.insertSubscribtionPrice(9, 7.5);
            DatabaseConnection.insertSubscribtionPrice(10, 3.5);





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
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("12/02/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("11/02/2019 14:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=17  },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("12/02/2019 15:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=3 },
new SubscriptionSchedule() {Schedule=DateTime.ParseExact("11/02/2019 09:00", "g", provider), Attendance=AttendanceTypes.Attended, SubscribtionID=15 },
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

        private void ვადაგასულიToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }





        private int daynumber = Convert.ToInt16(DateTime.Now.DayOfWeek);
        public void grafiki()
        {


            List<DateTime> gela = AddAbonent.Dates;
            var zvio = gela.FirstOrDefault(x => x.Date != null);
            


            dataGridView2.DataSource = null;
            dataGridView2.Rows.Add();

            for (int i = 10; i < 22; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i - 9].Cells[0].Value = Convert.ToString(i - 1 + ":00");
            }
            for (int i = 1; i < 13; i++)
            {
                for (int ii = 1; ii < daynumber; ii++)
                {
                    //dataGridView1.Rows[i].Cells[ii].Style.BackColor = Color.LightGray;
                    //dataGridView1.Rows[i].Cells[ii].Style.ForeColor = Color.Gray;

                }
            }
            for (int i = 0; i < 11; i++)
            {
                for (int ii = 0; ii < 7; ii++)
                {
                    dataGridView2.Rows[i].Cells[ii].DataGridView.DefaultCellStyle.BackColor = Color.Snow;
                }
            }

            //pirveli ujris shevseba DATE-biT

            int CurrentDay = (int)DateTime.Now.DayOfWeek;
            int ForwardDays = 6 - CurrentDay;
            int StartDay = CurrentDay - (CurrentDay - 1);

            dataGridView2.Rows[0].Cells[(int)DateTime.Now.DayOfWeek].Value = getFormattedDate(DateTime.Now);

            for (int i = 1; i <= ForwardDays; i++)
            {
                dataGridView2.Rows[0].Cells[(int)DateTime.Now.DayOfWeek + i].Value = getFormattedDate(DateTime.Now.AddDays(i));
            }

            for (int i = 1; i < CurrentDay; i++)
            {
                dataGridView2.Rows[0].Cells[(int)DateTime.Now.DayOfWeek - i].Value = getFormattedDate(DateTime.Now.AddDays(-i));
                // dataGridView1.Columns
            }

            //CultureInfo provider = new CultureInfo("fr-FR");
            //DateTime start = DateTime.ParseExact("21/01/2019 09:00", "g", provider);     //dateTimePicker1.Value;
            //6-(int)dateTimePicker1.Value.DayOfWeek
            //  DateTime End = dateTimePicker1.Value.AddDays(6 - (int)dateTimePicker1.Value.DayOfWeek);
            //   gridFillter(dataGridView1, DateTime.Now);
            dataGridView2.Rows[0].Cells[0].Value = " ";
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Green;
        }

        private string getFormattedDate(DateTime dateTime)
        {

            return dateTime.ToString("dd/MM/yyyy");
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }
    }
}


