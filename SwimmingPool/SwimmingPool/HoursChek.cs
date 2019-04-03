using SPSQLite;
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




        public SubscriptionScheduleDB Attendance(int attendanceNumber)
        {
            SubscriptionScheduleDB mamiko = new SubscriptionScheduleDB();

            var subscription = DatabaseConnection.Conn.GetAllWithChildren<Subscription>();

            var Schedule = DatabaseConnection.Conn.GetAllWithChildren<SubscriptionScheduleDB>();


            var subscriptionByID = DatabaseConnection.Conn.Table<Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault().Id;

            // es shesadareblad 
            // სამ 15:00 სთ    4 6 



            //var gela = Convert.ToInt32(GetAttendanceLabel.Substring(4, 2));
            //var DateNumber = Convert.ToInt32(GetHoursLabel.Substring(0, 2));

            var Hours = AttendLabel.Text;
            var Date = HoursLabel.Text;

            //var ScheduleByAbonent = Schedule.Where(x => x.Subscription.Id == subscriptionByID).FirstOrDefault(x=>x.Schedule.Day.ToString().Where(Date.Contains(x.Schedule.Day.ToString())) && x.Schedule.Hour.ToString().Contains(Hours));

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





            //}
            //else
            //{
            //    MessageBox.Show("aksjdhaksjdh");
            //}






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

        private void რედაქტირებაToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var subscriptionByID = DatabaseConnection.Conn.GetAllWithChildren<Subscription>().Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault();


            var ScheduleList = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>()
               .Where(x => x.IDnumber == Form1.selectedAbonentNumber).FirstOrDefault()
               .SubscribtionSchedule_.OrderBy(x => x.Schedule.Date).Select(x=>x.Schedule).ToList();

            Form1 A = new Form1();

          




            var IDnumber = subscriptionByID.IDnumber.ToString();
               var LastName = subscriptionByID.Subscriber_.LastName;
               var Name = subscriptionByID.Subscriber_.Name;
              
               var Adress = subscriptionByID.Subscriber_.Address;
               var PhoneNumber = subscriptionByID.Subscriber_?.PhoneNumber??0.ToString();
               var Age = subscriptionByID.Subscriber_.DateOfBirth;



                AddAbonent abonent = new AddAbonent(IDnumber, Name, LastName, PhoneNumber, Age, Adress, subscriptionByID);
            //abonent.Controls.Add(DataGridView datagridview1);
            A.EditFillGrid(abonent.dataGridView1, ScheduleList);
            abonent.Show();
            

        }
    }
}
