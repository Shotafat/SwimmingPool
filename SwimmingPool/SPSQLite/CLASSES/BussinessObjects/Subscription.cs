using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite.CLASSES
{
    public class Subscription : ISubscription
    {
        public int ID { get; set; }
        public int SubscriberID { get ; set; }
        public int DoctorID { get; set; }
        public int SubscribtionTypeID { get ; set ; }
        public int CoachID { get ; set ; }
    }
}
