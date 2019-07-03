using SPSQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SwimmingPool
{
    public partial class HoursChek : UserControl
    {

        public string GetHoursLabel { get { return HoursLabel.Text.ToString(); } set { HoursLabel.Text = value; } }
        public string GetAttendanceLabel { get { return AttendLabel.Text.ToString(); } set { AttendLabel.Text = value; } }
        public string GetAttendanceGela { get { return label1.Text.ToString(); } set { label1.Text = value; } }


        public HoursChek()
        {
            InitializeComponent();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }





        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void HoursLabel_Click(object sender, EventArgs e)
        {

        }

        private void AttendLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        public SubscriptionScheduleDB Attendance(int attendanceNumber)
        {
            SubscriptionScheduleDB mamiko = new SubscriptionScheduleDB();

            var subscription = DatabaseConnection.Conn.GetAllWithChildren<Subscription>();

            var Schedule = DatabaseConnection.Conn.GetAllWithChildren<SubscriptionScheduleDB>();


            var subscriptionByID = DatabaseConnection.Conn.Table<Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault().Id;
            var Hours = AttendLabel.Text;
            var Date = HoursLabel.Text;

            var schedule = (from g in Schedule
                            where (g.Subscription.Id == subscriptionByID)
                            select g).ToList();

            var TakeFinallyObject = (from g in schedule
                                     where (Date.Contains(g.Schedule.Day.ToString()) && Hours.Contains(g.Schedule.Hour.ToString()))
                                     select g);
            mamiko = TakeFinallyObject.FirstOrDefault();

            mamiko.Attandance = attendanceNumber; //gaacdina


            DatabaseConnection.Conn.Update(mamiko);
            return mamiko;
        }

        private void გაცდენაToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Attendance(2);

            GetAttendanceGela = "გააცდინა";
            BackColor = Color.Red;
        }


        private void HoursChek_DoubleClick(object sender, EventArgs e)
        {
            Attendance(0);
            GetAttendanceGela = "მოლოდინი";
            BackColor = Color.Gray;
        }

        private void დასვენებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAttendanceGela = "დასვენება";
            BackColor = Color.Teal;
            Attendance(3);
        }

        private void დასწრებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAttendanceGela = "დაესწრო";
            BackColor = Color.DarkSlateGray;
            Attendance(1);
        }
        
        public  List<DateTime> ScheduleList()
        {

            var ScheduleList = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>()
               .Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault()
               .SubscribtionSchedule_.OrderBy(x => x.Schedule.Date).Select(x => x.Schedule).ToList();
            return ScheduleList;
        }

        public void EdiTAbonent()
        {
            var subscriptionByID = DatabaseConnection.Conn.GetAllWithChildren<Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault();
            var subscriberByID = DatabaseConnection.Conn.GetAllWithChildren<Subscriber>().Where(x => x.SubscribtionID == subscriptionByID.Id).FirstOrDefault();

            Form1 A = new Form1();

            var IDnumber = subscriptionByID.IDnumber.ToString();
            var LastName = subscriptionByID.Subscriber_.LastName;
            var Name = subscriptionByID.Subscriber_.Name;
            var numberofHour = DatabaseConnection.Conn.Table<SubscribtionPrice>().Where(x => x.Id == subscriptionByID.SubscriberPrice_.Id).FirstOrDefault().NumberOfHours;
            var Adress = subscriptionByID.Subscriber_.Address;
            var PhoneNumber = subscriptionByID.Subscriber_.PhoneNumber.ToString();
            var Age = subscriptionByID.Subscriber_.DateOfBirth;


            List<DateTime> Dates = ScheduleList();

            var HasInquiry = subscriberByID.Healthnotice[0].YesNO;      

            AddAbonent abonent = new AddAbonent(IDnumber, Name, LastName, PhoneNumber, Age, Adress, subscriptionByID, Dates, numberofHour, HasInquiry, A);
            A.EditFillGrid(abonent, Dates);
             abonent.Show();      
        }

        private void რედაქტირებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EdiTAbonent();
        }
    }
}
