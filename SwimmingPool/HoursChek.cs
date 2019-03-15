using SPSQLite;
using SPSQLite.CLASSES.Services;
using SPSQLite.Enums;
using SQLiteNetExtensions.Extensions;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

        private void გაცდენაToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //abonent ID
            var abonentID = ServiceInstances.Service().GetSubscriptionServices().GetData().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault().ID;

            //Get Schedules with same abonent ID 

            var subscription = DatabaseConnection.Conn.GetAllWithChildren<Subscription>();

            var Schedule = DatabaseConnection.Conn.GetAllWithChildren<SubscriptionScheduleDB>();

            
            var subscriptionByID = DatabaseConnection.Conn.Table<Subscription>().Where(x=>x.IDnumber==Form1.selectedAbonentNumber).FirstOrDefault().Id;

            // es shesadareblad 
            // სამ 15:00 სთ    4   6 
            var array = GetAttendanceLabel.ToArray();

            var gela = GetAttendanceLabel.Substring(4, 2);
            var DateNumber = GetHoursLabel.Substring(0, 2);
            var ScheduleByAbonent = Schedule.Where(x => x.SubscriptionID == subscriptionByID).FirstOrDefault().Schedule;
            var realHour = Convert.ToInt32(ScheduleByAbonent.Hour);
           
            if (realHour.ToString().Equals(gela.ToString()) && ScheduleByAbonent.Day.ToString().Equals(DateNumber))
            {
                var gia = ServiceInstances.Service().GetSubscriptionScheduleServices().GetData().FirstOrDefault(x => x.SubscribtionID == subscriptionByID);

                gia.Attendance = AttendanceTypes.გააცდინა;
                ServiceInstances.Service().GetSubscriptionScheduleServices().UpdateSchedule(gia);

            }
            else
            {
                MessageBox.Show("aksjdhaksjdh");
            }







            //var miss = (int)AttendanceTypes.გააცდინა;

            //BackColor = Color.Red;


        }

        private void HoursChek_DoubleClick(object sender, EventArgs e)
        {
            if(BackColor!=Color.Gray)
            BackColor = Color.DarkSlateGray;
        }

        private void დასვენებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Teal;
        }

        
    }
}
