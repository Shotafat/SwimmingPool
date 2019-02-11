using System.Collections.Generic;


namespace SPSQLite.CLASSES
{
    public class Subscription : ISubscription
    {
        public int ID { get; set; }
        public string IDnumber { get; set; }
        public int SubscriberID { get; set; }

        public int SubscribtionTypeID { get; set; }
        public List<ISubscriptionSchedule> ScheduleList
        {

            get
            {

                return ScheduleList = new List<ISubscriptionSchedule>();
            }
            set
            {

            }

        }
    }
}
