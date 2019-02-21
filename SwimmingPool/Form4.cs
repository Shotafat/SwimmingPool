using SPSQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLiteNetExtensions.Extensions;

namespace SwimmingPool
{
    public partial class Form4 : Form
    {
        public List<SubscriptionScheduleDB> DBDB_old { get; set; }

        public Form4()
        {
            InitializeComponent();
            DBDB_old = DatabaseConnection.Conn.GetAllWithChildren<SPSQLite.SubscriptionScheduleDB>();
           ancient();
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
    }
}
