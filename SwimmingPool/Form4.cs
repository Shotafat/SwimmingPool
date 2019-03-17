using SPSQLite;
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
            var m = DBDB_old.FindAll(o => o.Schedule < DateTime.Now);

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
            old.DataSource = fillgrid;

        }

        public void last()
        {
            var schedule = DatabaseConnection.Conn.GetAllWithChildren<SubscriptionScheduleDB>();



            //var onlyDate = (from g in schedule
            //                select g.Schedule).ToList();

            var lastDate = schedule.Last().Schedule.Date.ToString("yyyy-MM-dd");
            var Today = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");

            //var lastDate = onlyDate.Last().Date;
            //var today = DateTime.Now.AddDays(-6);
            //if (lastDate == today)
            //{
            var subscriptions = DatabaseConnection.Conn.GetAllWithChildren<Subscription>();

            var onlyDates = subscriptions;



            var Name = subscriptions.Select(x => x.Subscriber_.Subscriptions.SubscribtionSchedule_);






            //var r = schedule.Where(
            //    .Select(g => new
            //    {

            //        აბონიმენტი = g.Subscription.IDnumber,
            //        სახელი = g.Subscription.Subscriber_.Name,
            //        გვარი = g.Subscription.Subscriber_.LastName,
            //        ასაკი = Math.Round((DateTime.Now - g.Subscription.Subscriber_.DateOfBirth).TotalDays / 365, 0),

            //        ფასი = g.Subscription.SubscriberPrice_.Price,
            //        საათი = g.Subscription.SubscriberPrice_.NumberOfHours



            //    }).ToList();





            var r = (from g in subscriptions
                     where g.SubscribtionSchedule_.OrderBy(x => x.Schedule.Date).Last().Schedule.Date.ToString("yyyy-MM-dd") == DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")

                     select new
                     {
                         აბონიმენტი = g.IDnumber,
                         სახელი = g.Subscriber_.Name,
                         გვარი = g.Subscriber_.LastName,
                         ასაკი = Math.Round((DateTime.Now - g.Subscriber_.DateOfBirth).TotalDays / 365, 0),

                         ფასი = g.SubscriberPrice_.Price,
                         საათი = g.SubscriberPrice_.NumberOfHours
                     }).ToList();

            old.DataSource = r;













        }
    }
}