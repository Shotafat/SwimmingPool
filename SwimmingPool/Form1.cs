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

        public List<SubscriptionScheduleDB> DBDB { get; set; }

        public Form1()
        {
           
     

            InitializeComponent();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
        }

       
      
        private void Form1_Load(object sender, EventArgs e)
        {
        
            
            dataGridView1.AutoGenerateColumns = true;

      


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

             DBDB = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.SubscriptionScheduleDB>();
            var subscriber = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscriber>();

         var scheduledb = (from o in DBDB select new { ID =o.Id, Sub=o.Subscription.IDnumber}).ToList();



         var SubscribtionTable=DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>();

            var subfromsubscribtion = (from o in SubscribtionTable select new { ID = o.Id, subscriberName = o.Subscriber_.Id, PriceTyme=o.SubscriberPrice_.Id }).ToList();
            var subTa =(from o in SubscribtionTable select new { IDDD = o.IDnumber, Name=o.Subscriber_.LastName, nn=o.Subscriber_.Healthnotice }).ToList();




            var HealthTable = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.HealthNotice>();

         MessageBox.Show("BAZIS METHODIS BOLOS" +scheduledb.Count().ToString());


            var fillgrid = (from o in SubscribtionTable
                            join a in HealthTable on o.Subscriber_.Id equals a.SubscriberID
                            select new
                            {
                                აბონიმენტი = o.IDnumber,
                                სახელი = o.Subscriber_.Name,
                                გვარი = o.Subscriber_.LastName,
                                ასაკი = Math.Round((DateTime.Now - o.Subscriber_.DateOfBirth).TotalDays / 365, 0),
                                ჯანმრთელობისცნობა = a.YesNO,
                                ფასი = o.SubscriberPrice_.Price,
                                საათი=o.SubscriberPrice_.NumberOfHours

                            }).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = fillgrid;
        }





        string monthName;
        string WeekDay;
        int DayNumber;
        public void GeoCulture()
        {
          


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           


            flowLayoutPanel1.Controls.Clear();
            this.Refresh();
            var selectedrowindex = dataGridView1.SelectedCells[0].Value;
            label3.Text = null;
            label3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()+ " " + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


           

            var DBDB = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.SubscriptionScheduleDB>();
            var SelectedSubscribtion = (from o in DBDB where o.Subscription.IDnumber == selectedrowindex.ToString() select new { Ganrigi = o.Schedule, Daswreba = o.Attandance.ToString() }).ToList();

          
            //HoursChek Hours = new HoursChek();
            foreach (var item in SelectedSubscribtion)
            {

                var gela = item.Ganrigi.Month;

                var geoCulture = new CultureInfo("ka-GE");

                var dateTimeInfo = DateTimeFormatInfo.GetInstance(geoCulture);

                var weekDay = item.Ganrigi.DayOfWeek;


                monthName = dateTimeInfo.GetAbbreviatedMonthName(gela);
                WeekDay = dateTimeInfo.GetAbbreviatedDayName(weekDay);
                DayNumber = item.Ganrigi.Day;

                int aa = Convert.ToInt32(item.Daswreba);
                AttendanceTypes Attend = new AttendanceTypes();
                Attend=(AttendanceTypes)aa;


                //DateTime gela = DateTime.Parse(item.Ganrigi, new CultureInfo("ka-Ge"));

                ////DateTime DateOfBirth = DateTime.ParseExact(item.Ganrigi, "MM-dd-yyyy", new CultureInfo("ka-GE"));



                HoursChek Hours = new HoursChek ();
                Hours.GetHoursLabel = DayNumber  + " "+ monthName;
                Hours.GetAttendanceLabel = WeekDay + " " + item.Ganrigi.Hour + ":00 სთ";
                Hours.GetAttendanceGela = Attend.ToString();
                flowLayoutPanel1.Controls.Add(Hours);

            
            }

          




            //if (dataGridView1.SelectedCells.Count > 0)
            //{
            //    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

            //    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            //    string a = Convert.ToString(selectedRow.Cells[1].Value);
            //    string b = Convert.ToString(selectedRow.Cells[2].Value);
            //    //label1.Text = a + " " + b;
            //}
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
       
          

        }

        private void ვადაგასულიToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }





        private int daynumber = Convert.ToInt16(DateTime.Now.DayOfWeek);
       

        private string getFormattedDate(DateTime dateTime)
        {

            return dateTime.ToString("dd/MM/yyyy");
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }
    }
}


