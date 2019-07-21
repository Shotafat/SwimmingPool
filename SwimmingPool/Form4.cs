using SPSQLite;
using SPSQLite.CLASSES.Services;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SwimmingPool
{
    public partial class Form4 : Form
    {
        public List<SubscriptionScheduleDB> DBDB_old { get; set; }

        public Form4()
        {
            InitializeComponent();
            DBDB_old = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.SubscriptionScheduleDB>();
            //ancient();
            last();
        }



        public void ancient()
        {
            var m = DBDB_old.FindAll(o => o.Schedule.DayOfYear < DateTime.Now.DayOfYear);

            var subscriber = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscriber>();

            var scheduledb = (from o in m select new { ID = o.Id, Sub = o.Subscription.IDnumber }).ToList();



            var SubscribtionTable = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>();

            var subfromsubscribtion = (from o in SubscribtionTable select new { ID = o.Id, subscriberName = o.Subscriber_.Id, PriceTyme = o.SubscriberPrice_.Id }).ToList();
            var subTa = (from o in SubscribtionTable select new { IDDD = o.IDnumber, Name = o.Subscriber_.LastName, nn = o.Subscriber_.Healthnotice }).ToList();




            var HealthTable = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.HealthNotice>();

            MessageBox.Show("BAZIS METHODIS BOLOS" + scheduledb.Count().ToString());


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
                                საათი = o.SubscriberPrice_.NumberOfHours
                            }).ToList();

            datagridview4.DataSource = fillgrid;
        }

        public List<object> last()
        {
            var schedule = DatabaseConnection.Conn.GetAllWithChildren<SubscriptionScheduleDB>();          
            var Today = DateTime.Now.ToString("yyyy-MM-dd");
            var subscriptions = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>();            
            var onlyDates = subscriptions;
            var Name = subscriptions.Select(x => x.Subscriber_.Subscriptions.SubscribtionSchedule_);

            List<object> r = new List<object>();

            r = (from g in subscriptions
                      where g.SubscribtionSchedule_.OrderBy(x => x.Schedule.Date.DayOfYear).Last().Schedule.DayOfYear < DateTime.Now.DayOfYear
                      select new
                         {
                             აბონიმენტი = g.IDnumber,
                             სახელი = g.Subscriber_.Name,
                             გვარი = g.Subscriber_.LastName,
                             ასაკი = Math.Round((DateTime.Now - g.Subscriber_.DateOfBirth).TotalDays / 365, 0),

                             ფასი = g.SubscriberPrice_.Price,
                             საათი = g.SubscriberPrice_.NumberOfHours
                         }).ToList<object>();

                datagridview4.DataSource = r;         
           
            return r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stringNumber = datagridview4.SelectedCells[0].Value.ToString();
            var obj = ServiceInstances.Service().GetSubscriptionServices().GetData().FirstOrDefault(x => x.IDnumber == stringNumber);
            ServiceInstances.Service().GetSubscriptionServices().Delete(obj);
        }



        public List<DateTime> ScheduleList(string selectedcell)
        {

            var ScheduleList = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.Subscription>()
               .Where(x => x.IDnumber == selectedcell).FirstOrDefault()
               .SubscribtionSchedule_.OrderBy(x => x.Schedule.Date).Select(x => x.Schedule).ToList();
            return ScheduleList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedAbonentNumber = datagridview4.SelectedCells[0].Value.ToString();

            var subscriptionByID = DatabaseConnection.Conn.GetAllWithChildren<Subscription>().Where
                (x => x.IDnumber ==selectedAbonentNumber).FirstOrDefault();

            Form1 A = new Form1();           

            HoursChek Hoursch = new HoursChek();

            var IDnumber = subscriptionByID.IDnumber.ToString();
            var LastName = subscriptionByID.Subscriber_.LastName;
            var Name = subscriptionByID.Subscriber_.Name;

            var Adress = subscriptionByID.Subscriber_.Address;
            var PhoneNumber = subscriptionByID.Subscriber_.PhoneNumber.ToString();
            var Age = subscriptionByID.Subscriber_.DateOfBirth;


            List<DateTime> Dates = ScheduleList(selectedAbonentNumber);
            AddAbonent abonent = new AddAbonent(IDnumber, Name, LastName, PhoneNumber, Age, Adress, subscriptionByID, Dates, true);
            
            //abonent.Controls.Add(DataGridView datagridview1);
            A.EditFillGrid(abonent, Dates);
            this.Close();

            abonent.Show();
        }
    }
}