using SPSQLite.Enums;
using System;

namespace SPSQLite.CLASSES
{
    public class SubscriptionSchedule : ISubscriptionSchedule
    {
        public int ID { get; set; }
        public DateTime Schedule { get; set; }
        public int SubscribtionID { get; set; }
        public AttendanceTypes Attendance { get; set; }
        public ISubscription Subscription
        {
            get {return Subscription =  new Subscription(); }
            set { }
        }
    }
}
